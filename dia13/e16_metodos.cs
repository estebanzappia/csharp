decimal valorProducto = 150000m;

Console.WriteLine($"Precio sin IVA: {valorProducto}");
Console.WriteLine($"IVA 10%: {CalcularIva(valorProducto, 10)}");
Console.WriteLine($"Total con IVA 10%: {PrecioConIva(valorProducto, 10)}");
Console.WriteLine($"Total con IVA 5%: {PrecioConIva(valorProducto, 5)}");

decimal CalcularIva(decimal monto, decimal porcentaje)
{
    return monto * porcentaje / 100;
}

decimal PrecioConIva(decimal monto, decimal porcentaje)
{
    return monto + CalcularIva(monto, porcentaje);
}