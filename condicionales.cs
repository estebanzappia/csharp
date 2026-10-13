using System;
Console.WriteLine("Ingrese su edad: ");
int edad = Convert.ToInt32(Console.ReadLine());
if (edad >= 18) {
    Console.WriteLine("Bienvenido al club");
    if (edad >= 20)
    {
        Console.WriteLine("Desea una bebida?");
        Console.WriteLine(Console.ReadLine());
        Console.WriteLine("Aquí tiene su bebida");
    }
    else
    {
        Console.WriteLine("Desea una coca?");
        Console.WriteLine(Console.ReadLine());
        Console.WriteLine("Aquí tiene su coca");
    }
}
else {
    Console.WriteLine("Acceso denegado");
}