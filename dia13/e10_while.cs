int acumuladoSuma = 0;
int totalElementos = 0;

Console.Write("Número (0 para terminar): ");
int valorIngresado = int.Parse(Console.ReadLine()!);

while (valorIngresado != 0)
{
    acumuladoSuma += valorIngresado;
    totalElementos++;

    Console.Write("Número (0 para terminar): ");
    valorIngresado = int.Parse(Console.ReadLine()!);
}

Console.WriteLine($"Cantidad: {totalElementos}");
Console.WriteLine($"Suma: {acumuladoSuma}");

if (totalElementos > 0)
{
    double promedioFinal = (double)acumuladoSuma / totalElementos;
    Console.WriteLine($"Promedio: {promedioFinal}");
}