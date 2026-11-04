int valorElegido;

do
{
    Console.Write("Elige un número del 1 al 10: ");
    valorElegido = int.Parse(Console.ReadLine()!);

    if (valorElegido < 1 || valorElegido > 10)
    {
        Console.WriteLine("Fuera de rango, intenta de nuevo.");
    }
}
while (valorElegido < 1 || valorElegido > 10);

Console.WriteLine($"Elegiste el {valorElegido}.");