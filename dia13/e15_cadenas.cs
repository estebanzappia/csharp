Console.Write("Escribe una frase: ");
string textoUsuario = Console.ReadLine() ?? "";

int totalVocales = 0;

foreach (char caracter in textoUsuario.ToLower())
{
    if ("aeiouáéíóú".Contains(caracter))
    {
        totalVocales++;
    }
}

Console.WriteLine($"Mayúsculas: {textoUsuario.ToUpper()}");
Console.WriteLine($"Largo: {textoUsuario.Length}");
Console.WriteLine($"Vocales: {totalVocales}");
