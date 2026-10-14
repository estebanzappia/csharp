Console.WriteLine("Conversión de guaranies a dolares");
Console.WriteLine("---------------------------------");
Console.WriteLine("Escriba la cotización del dolar: ");
double cotizaciones = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Escriba el monto en guaranies a convertir: ");
double guaranies = Convert.ToDouble(Console.ReadLine());
double dolares = guaranies / cotizaciones;
Console.WriteLine($"Son {dolares:N2} dolares.");