Tarjeta tarjeta = new Tarjeta("Lucía Benítez", 13288);
tarjeta.PagarPasaje(15000);
tarjeta.MostrarInfo();

class Tarjeta
{
    private int _saldo;
    public string Titular { get; }
    public int Saldo
    {
        get { return _saldo; }
    }

    public Tarjeta(string titular, int saldo)
    {
        Titular = titular;
        _saldo = saldo;
    }

    public void PagarPasaje(int costo)
    {
        if (Saldo < costo)
        {
            Console.WriteLine("Saldo insuficiente.");
        }
        else
        {
            _saldo -= costo;
        }
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo: {Saldo} Gs");
    }
}