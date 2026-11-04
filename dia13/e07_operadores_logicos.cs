Console.Write("Introduce un año: ");
string entrada = Console.ReadLine()!;
int anioIngresado = int.Parse(entrada);

bool esAnioBisiesto = (anioIngresado % 4 == 0 && anioIngresado % 100 != 0) || (anioIngresado % 400 == 0);

if (esAnioBisiesto)
{
    Console.WriteLine($"{anioIngresado} es bisiesto.");
}
else
{
    Console.WriteLine($"{anioIngresado} no es bisiesto.");
}