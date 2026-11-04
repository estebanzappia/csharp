Console.Write("Introduce tu edad: ");
string inputEdad = Console.ReadLine()!;
int edadUsuario = int.Parse(inputEdad);

if (edadUsuario >= 18)
{
    Console.WriteLine("Eres mayor de edad.");
}

Console.WriteLine("Fin del programa.");