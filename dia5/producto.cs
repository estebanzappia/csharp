using System;
using System.Collections.Generic;


List<Producto> inventario = new List<Producto>();


inventario.Add(new Producto("K001", "Gaseosa 500 ml", 6000, 24, 6));
inventario.Add(new Producto("K002", "Alfajor", 3500, 40, 10));
inventario.Add(new Producto("K003", "Agua mineral 1 l", 4500, 8, 6));


inventario[0].Vender(5);    
inventario[2].Vender(4);    
inventario[1].Vender(100);  

Console.WriteLine("=== Inventario del kiosco ===");
foreach (Producto p in inventario)
{
    p.Mostrar();
}



class Producto
{
    private int _stock;
    private double _precioventa;

    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int StockMinimo { get; set; }

    public double PrecioVenta
    {
        get { return _precioventa; }
        set
        {
            if (value > 0)
                _precioventa = value;
        }
    }

    public int Stock
    {
        get { return _stock; }
    }

    public Producto(string codigo, string nombre, double precioVenta, int stock, int stockMinimo)
    {
        Codigo = codigo;
        Nombre = nombre;
        PrecioVenta = precioVenta;
        _stock = stock;
        StockMinimo = stockMinimo;
    }

    public bool Vender(int cantidad)
    {
        if (cantidad <= 0 || cantidad > _stock)
        {
            Console.WriteLine("No se puede vender " + cantidad + " de " + Nombre + ".");
            return false;
        }
        _stock -= cantidad;
        return true;
    }

    public void Reponer(int cantidad)
    {
        if (cantidad > 0)
            _stock += cantidad;
    }

    public bool NecesitaReposicion()
    {
        return _stock <= StockMinimo;
    }

    public void Mostrar()
    {
        string aviso = "";
        if (NecesitaReposicion())
            aviso = "  [reponer]";

        Console.WriteLine(Codigo + " " + Nombre + " - " + PrecioVenta.ToString("N0") + " Gs - stock: " + _stock + aviso);
    }
}