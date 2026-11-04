Console.Write("¿En qué año naciste? ");
string entradaUsuario = Console.ReadLine() ?? "";

if (int.TryParse(entradaUsuario, out int anoNacimiento))
{
    int anioEnCurso = 2026;
    int calculoEdad = anioEnCurso - anoNacimiento;
    Console.WriteLine($"Tienes aproximadamente {calculoEdad} años.");
}
else
{
    Console.WriteLine("Eso no es un año válido.");
}