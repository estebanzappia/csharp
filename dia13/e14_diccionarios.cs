Dictionary<string, int> inventario = new Dictionary<string, int>
{
    { "manzana", 20 },
    { "banana", 35 },
    { "naranja", 12 }
};

inventario["manzana"] -= 3;
inventario["pera"] = 8;

foreach (KeyValuePair<string, int> elemento in inventario)
{
    Console.WriteLine($"{elemento.Key}: {elemento.Value}");
}

if (inventario.TryGetValue("uva", out int cantidadUvas))
{
    Console.WriteLine($"Uvas: {cantidadUvas}");
}
else
{
    Console.WriteLine("No hay uvas en el inventario.");
}