int[] listaTemperaturas = { 28, 31, 25, 33, 30, 27 };

int tempMax = listaTemperaturas[0];
int tempMin = listaTemperaturas[0];
int acumuladoTotal = 0;

foreach (int temp in listaTemperaturas)
{
    if (temp > tempMax)
    {
        tempMax = temp;
    }

    if (temp < tempMin)
    {
        tempMin = temp;
    }

    acumuladoTotal += temp;
}

Console.WriteLine($"Mayor: {tempMax}");
Console.WriteLine($"Menor: {tempMin}");

double promedioTemp = (double)acumuladoTotal / listaTemperaturas.Length;
Console.WriteLine($"Promedio: {promedioTemp}");