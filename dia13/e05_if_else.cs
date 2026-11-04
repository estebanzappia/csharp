Console.Write("Escribe un número: ");
string input = Console.ReadLine()!;
int num = int.Parse(input);

bool esPar = (num % 2 == 0);

if (esPar)
{
    Console.WriteLine($"{num} es par.");
}
else
{
    Console.WriteLine($"{num} es impar.");
}