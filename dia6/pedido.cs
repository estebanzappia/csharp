public class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }

    public void Presentarse()
    {
        Console.WriteLine("Hola, soy " + Nombre + ".");
    }
}

// Cliente hereda de persona
public class Cliente : Persona
{
    public string Telefono { get; set; }

    public Cliente(string nombre, string telefono) : base(nombre)
    {
        Telefono = telefono;
    }
}

public class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public Producto(string nombre, double precio)
    {
        Nombre = nombre;
        Precio = precio;
    }
}

public class PedidoDetalle
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }

    public PedidoDetalle(Producto producto, int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }

    public double CalcularSubtotal()
    {
        return Producto.Precio * Cantidad;
    }
}

public class Pedido
{
    public Cliente Cliente { get; set; }
    // Composición: La lista de detalles vive dentro del Pedido y las crea él mismo
    public List<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();

    public Pedido(Cliente cliente)
    {
        Cliente = cliente;
    }

   
    public void AgregarDetalle(Producto producto, int cantidad)
    {
        PedidoDetalle detalle = new PedidoDetalle(producto, cantidad);
        Detalles.Add(detalle);
    }

    public void MostrarPedido()
    {
        Console.WriteLine($"Pedido de {Cliente.Nombre} ({Cliente.Telefono})");

        double total = 0;
        foreach (var detalle in Detalles)
        {
            double subtotal = detalle.CalcularSubtotal();
            total += subtotal;
            Console.WriteLine($"{detalle.Cantidad} x {detalle.Producto.Nombre} = {subtotal:N0} Gs");
        }

        Console.WriteLine($"Total: {total:N0} Gs");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 1. Crear el cliente y los productos afuera (Asociación)
        Cliente cliente = new Cliente("Lucía Benítez", "0981 123 456");

        Producto p1 = new Producto("Gaseosa 500 ml", 6000);
        Producto p2 = new Producto("Alfajor", 3500);

       
        Pedido pedido = new Pedido(cliente);

        
        pedido.AgregarDetalle(p1, 3);
        pedido.AgregarDetalle(p2, 2);

        
        pedido.MostrarPedido();
    }
}