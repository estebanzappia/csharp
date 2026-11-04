Console.Write("Ingrese un num: ");
string input = Console.ReadLine();
int num = int.Parse(input);

long resultado = Factorial(num);
Console.WriteLine(num + "! = " + resultado);

long Factorial(int n)
{
    // caso base
    if (n <= 1)
    {
        return 1;
    }

    return n * Factorial(n - 1);
}