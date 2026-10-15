using System;
using System.Collections.Generic;

// 1. Catálogos y diccionarios (RETO 2: Se agrega producto exento)
Dictionary<string, double> precios = new Dictionary<string, double>
{
    { "Medialuna", 2500 },
    { "Chipa", 3000 },
    { "Pan por kilo", 12000 },
    { "Gaseosa", 8000 },
    { "Leche", 9500 },
    { "Agua Mineral", 4000 } // Producto exento de IVA
};

Dictionary<string, int> tasasIva = new Dictionary<string, int>
{
    { "Medialuna", 10 },
    { "Chipa", 10 },
    { "Pan por kilo", 5 },
    { "Gaseosa", 10 },
    { "Leche", 5 },
    { "Agua Mineral", 0 } // Tasa de IVA 0 %
};

// 2. Mostrar el catálogo inicial
Console.WriteLine("=== Catálogo ===");
foreach (string producto in precios.Keys)
{
    Console.WriteLine(producto + ": " + FormatoGs(precios[producto]));
}
Console.WriteLine();

// 3. Listas para el carrito y bucle para agregar productos
List<string> carrito = new List<string>();
List<int> unidades = new List<int>();

string respuesta = "s";
while (respuesta == "s")
{
    Console.Write("Producto: ");
    string nombre = Console.ReadLine();

    if (!precios.ContainsKey(nombre))
    {
        Console.WriteLine("Ese producto no está en el catálogo.");
    }
    else
    {
        Console.Write("Cantidad: ");
        int cantidadPedida = int.Parse(Console.ReadLine());
        carrito.Add(nombre);
        unidades.Add(cantidadPedida);
    }

    Console.Write("¿Agregar otro producto? (s/n): ");
    respuesta = Console.ReadLine();
}

// RETO 3: Quitar el último producto si el cliente lo desea
if (carrito.Count > 0)
{
    Console.Write("¿Desea quitar el último producto ingresado? (s/n): ");
    string opcionQuitar = Console.ReadLine();
    if (opcionQuitar.ToLower() == "s")
    {
        int ultimoIndice = carrito.Count - 1;
        Console.WriteLine("Se ha quitado: " + carrito[ultimoIndice]);

        // Al haber dos listas paralelas, hay que remover el mismo índice en ambas:
        carrito.RemoveAt(ultimoIndice);
        unidades.RemoveAt(ultimoIndice);
    }
}

// 4. Cálculo y generación de la factura
Console.Write("Descuento en porcentaje (0 si no hay): ");
double descuento = double.Parse(Console.ReadLine());

// RETO 1: Calcular subtotal bruto previo para determinar descuento automático si ingresó 0
double subtotalBrutoPrevio = 0;
for (int i = 0; i < carrito.Count; i++)
{
    subtotalBrutoPrevio += CalcularSubtotal(precios[carrito[i]], unidades[i]);
}

if (descuento == 0)
{
    descuento = CalcularDescuentoAutomatico(subtotalBrutoPrevio);
    if (descuento > 0)
    {
        Console.WriteLine("¡Se aplicó un descuento automático del " + descuento + "% por superar 100.000 Gs.!");
    }
}

double totalBruto = 0;
double totalNeto = 0;
double iva10 = 0;
double iva5 = 0;

Console.WriteLine();
Console.WriteLine("=== FACTURA ===");
for (int i = 0; i < carrito.Count; i++)
{
    string nombreItem = carrito[i];
    double bruto = CalcularSubtotal(precios[nombreItem], unidades[i]);
    double neto = AplicarDescuento(bruto, descuento);

    totalBruto += bruto;
    totalNeto += neto;

    // RETO 2: Corrección para que la tasa 0 % no se sume al IVA 5 %
    if (tasasIva[nombreItem] == 10)
    {
        iva10 += CalcularIva(neto, 10);
    }
    else if (tasasIva[nombreItem] == 5)
    {
        iva5 += CalcularIva(neto, 5);
    }

    Console.WriteLine(unidades[i] + " x " + nombreItem + ": " + FormatoGs(bruto));
}

Console.WriteLine("Subtotal: " + FormatoGs(totalBruto));
Console.WriteLine("Descuento (" + descuento + " %): -" + FormatoGs(totalBruto - totalNeto));
Console.WriteLine("TOTAL A PAGAR: " + FormatoGs(totalNeto));
Console.WriteLine("IVA 10 % incluido: " + FormatoGs(iva10));
Console.WriteLine("IVA 5 % incluido: " + FormatoGs(iva5));

// 5. Métodos auxiliares
string FormatoGs(double valor)
{
    return valor.ToString("N0") + " Gs.";
}

double CalcularSubtotal(double precioUnitario, int cantidad)
{
    return precioUnitario * cantidad;
}

double AplicarDescuento(double subtotal, double porcentajeDescuento)
{
    return subtotal - (subtotal * porcentajeDescuento / 100);
}

double CalcularIva(double montoNeto, int tasa)
{
    return montoNeto * tasa / (100 + tasa);
}

// RETO 1: Método para el descuento automático
double CalcularDescuentoAutomatico(double subtotal)
{
    if (subtotal > 100000)
    {
        return 5;
    }
    return 0;
}