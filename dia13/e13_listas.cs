List<string> listaCompras = new List<string> { "pan", "leche", "huevos" };

listaCompras.Add("yerba");
listaCompras.Insert(0, "arroz");
listaCompras.Remove("leche");
listaCompras.Sort();

Console.WriteLine($"Cantidad: {listaCompras.Count}");

foreach (string item in listaCompras)
{
    Console.WriteLine($"- {item}");
}

Console.WriteLine($"¿Hay huevos? {listaCompras.Contains("huevos")}");