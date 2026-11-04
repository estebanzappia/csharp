Console.Write("Introduce tu nota (0 a 100): ");
int calificacion = int.Parse(Console.ReadLine()!);

if (calificacion < 0 || calificacion > 100)
{
    Console.WriteLine("Nota inválida.");
}
else if (calificacion >= 90)
{
    Console.WriteLine("Excelente");
}
else if (calificacion >= 75)
{
    Console.WriteLine("Bueno");
}
else if (calificacion >= 60)
{
    Console.WriteLine("Aprobado");
}
else
{
    Console.WriteLine("Reprobado");
}