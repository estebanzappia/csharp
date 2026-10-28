using Microsoft.AspNetCore.Mvc;
using Finanzas.Data;
using Finanzas.Models;

namespace Finanzas.Controllers;

public class MovimientosController : Controller
{
    private readonly MovimientoRepositorio _repositorio;

    public MovimientosController(IConfiguration configuracion)
    {
        _repositorio = new MovimientoRepositorio(configuracion);
    }

    public IActionResult Index()
    {
        return View(_repositorio.ObtenerTodos());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Movimiento movimiento)
    {
        if (ModelState.IsValid)
        {
            _repositorio.Agregar(movimiento);
            return RedirectToAction(nameof(Index));
        }
        return View(movimiento);
    }

    public IActionResult Edit(int id)
    {
        Movimiento? movimiento = _repositorio.ObtenerPorId(id);
        if (movimiento == null)
            return NotFound();

        return View(movimiento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Movimiento movimiento)
    {
        if (!ModelState.IsValid)
            return View(movimiento);

        _repositorio.Actualizar(movimiento);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Movimiento? movimiento = _repositorio.ObtenerPorId(id);
        if (movimiento == null)
            return NotFound();

        return View(movimiento);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repositorio.Eliminar(id);
        return RedirectToAction("Index");
    }
}