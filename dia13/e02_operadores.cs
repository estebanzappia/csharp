int x = 17;
int y = 5;

int totalSuma = x + y;
int totalResta = x - y;

Console.WriteLine("Suma: " + totalSuma);
Console.WriteLine("Resta: " + totalResta);
Console.WriteLine("Multiplicación: " + (x * y));
Console.WriteLine($"División entera: {x / y}");
Console.WriteLine($"Resto de la división: {x % y}");

double divReal = (double)x / y;
Console.WriteLine("División real: " + divReal);
Console.WriteLine($"Cuadrado de a: {Math.Pow(x, 2)}");