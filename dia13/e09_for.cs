Console.Write("Ingrese un número: ");
string entrada = Console.ReadLine()!;
int numeroTabla = int.Parse(entrada);

for (int contador = 1; contador <= 10; contador++)
{
    int resultado = numeroTabla * contador;
    Console.WriteLine($"{numeroTabla} x {contador} = {resultado}");
}