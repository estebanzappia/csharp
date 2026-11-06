using Microsoft.AspNetCore.Mvc;
using Canchas.Data;
using Canchas.Models;

namespace Canchas.Controllers
{
    public class JuegoController : Controller
    {
        private readonly SupabaseCliente _supabase;

        public JuegoController(SupabaseCliente supabase)
        {
            _supabase = supabase;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Iniciar(string jugador)
        {
            if (string.IsNullOrWhiteSpace(jugador))
            {
                ViewBag.Error = "Por favor, ingresa tu nombre.";
                return View("Index");
            }

            int numeroSecreto = new Random().Next(1, 101);
            HttpContext.Session.SetString("Jugador", jugador.Trim());
            HttpContext.Session.SetInt32("NumeroSecreto", numeroSecreto);
            HttpContext.Session.SetInt32("Intentos", 0);
            HttpContext.Session.SetInt32("Estado", 0);

            return RedirectToAction("Tablero");
        }

        public IActionResult Tablero()
        {
            string? jugador = HttpContext.Session.GetString("Jugador");
            int? numeroSecreto = HttpContext.Session.GetInt32("NumeroSecreto");

            if (string.IsNullOrEmpty(jugador) || !numeroSecreto.HasValue)
                return RedirectToAction("Index");

            ViewBag.Jugador = jugador;
            ViewBag.Intentos = HttpContext.Session.GetInt32("Intentos") ?? 0;
            ViewBag.Pista = TempData["Pista"];
            ViewBag.Error = TempData["Error"];

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adivinar(int numero)
        {
            string? jugador = HttpContext.Session.GetString("Jugador");
            int? numeroSecreto = HttpContext.Session.GetInt32("NumeroSecreto");
            int intentos = HttpContext.Session.GetInt32("Intentos") ?? 0;

            if (string.IsNullOrEmpty(jugador) || !numeroSecreto.HasValue)
                return RedirectToAction("Index");

            if (numero < 1 || numero > 100)
            {
                TempData["Error"] = "Debes ingresar un número válido entre 1 y 100.";
                return RedirectToAction("Tablero");
            }

            intentos++;
            HttpContext.Session.SetInt32("Intentos", intentos);

            if (numero == numeroSecreto.Value)
            {
                int puntos = Math.Max(10, 100 - (intentos - 1) * 15);
                HttpContext.Session.SetInt32("Puntos", puntos);
                HttpContext.Session.SetInt32("Estado", 1);

                await _supabase.Insertar("puntajes", new Puntaje { Jugador = jugador, Puntos = puntos });
                return RedirectToAction("Resultado");
            }

            if (intentos >= 7)
            {
                HttpContext.Session.SetInt32("Estado", 2);
                return RedirectToAction("Resultado");
            }

            TempData["Pista"] = numero < numeroSecreto.Value
                ? $"El número secreto es MAYOR que {numero}."
                : $"El número secreto es MENOR que {numero}.";

            return RedirectToAction("Tablero");
        }

        public IActionResult Resultado()
        {
            string? jugador = HttpContext.Session.GetString("Jugador");
            int? estado = HttpContext.Session.GetInt32("Estado");

            if (string.IsNullOrEmpty(jugador) || !estado.HasValue || estado.Value == 0)
                return RedirectToAction("Index");

            ViewBag.Jugador = jugador;
            ViewBag.Estado = estado.Value;
            ViewBag.Puntos = HttpContext.Session.GetInt32("Puntos") ?? 0;
            ViewBag.NumeroSecreto = HttpContext.Session.GetInt32("NumeroSecreto");
            ViewBag.Intentos = HttpContext.Session.GetInt32("Intentos");

            return View();
        }

        public async Task<IActionResult> Ranking()
        {
            var registros = await _supabase.Listar<Puntaje>("puntajes?select=*&order=puntos.desc,creado.asc&limit=10");
            return View(registros);
        }
    }
}