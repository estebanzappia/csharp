using Finanzas.Models;
using MySqlConnector;

namespace Finanzas.Data;

public class MovimientoRepositorio
{
    private readonly string _cadenaConexion;

    public MovimientoRepositorio(IConfiguration configuracion)
    {
        _cadenaConexion = configuracion.GetConnectionString("Mysql") ?? "";
    }

    public List<Movimiento> ObtenerTodos()
    {
        var lista = new List<Movimiento>();

        using var conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();

        using var comando = new MySqlCommand(
            "SELECT id, monto, tipo, descripcion FROM movimientos ORDER BY id DESC", conexion);
        using var lector = comando.ExecuteReader();

        while (lector.Read())
        {
            lista.Add(new Movimiento
            {
                Id = lector.GetInt32("id"),
                Monto = lector.GetInt32("monto"),
                Tipo = Enum.Parse<TipoMovimiento>(lector.GetString("tipo")),
                Descripcion = lector.GetString("descripcion")
            });
        }

        return lista;
    }

    public Movimiento? ObtenerPorId(int id)
    {
        using var conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();

        using var comando = new MySqlCommand(
            "SELECT id, monto, tipo, descripcion FROM movimientos WHERE id = @id", conexion);
        comando.Parameters.AddWithValue("@id", id);
        using var lector = comando.ExecuteReader();

        if (!lector.Read())
            return null;

        return new Movimiento
        {
            Id = lector.GetInt32("id"),
            Monto = lector.GetInt32("monto"),
            Tipo = Enum.Parse<TipoMovimiento>(lector.GetString("tipo")),
            Descripcion = lector.GetString("descripcion")
        };
    }

    public void Agregar(Movimiento movimiento)
    {
        using var conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();

        using var comando = new MySqlCommand(
            "INSERT INTO movimientos (monto, tipo, descripcion) VALUES (@monto, @tipo, @descripcion)", conexion);
        comando.Parameters.AddWithValue("@monto", movimiento.Monto);
        comando.Parameters.AddWithValue("@tipo", movimiento.Tipo.ToString());
        comando.Parameters.AddWithValue("@descripcion", movimiento.Descripcion);
        comando.ExecuteNonQuery();
    }

    public void Actualizar(Movimiento movimiento)
    {
        using var conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();

        using var comando = new MySqlCommand(
            "UPDATE movimientos SET monto = @monto, tipo = @tipo, descripcion = @descripcion WHERE id = @id", conexion);
        comando.Parameters.AddWithValue("@monto", movimiento.Monto);
        comando.Parameters.AddWithValue("@tipo", movimiento.Tipo.ToString());
        comando.Parameters.AddWithValue("@descripcion", movimiento.Descripcion);
        comando.Parameters.AddWithValue("@id", movimiento.Id);
        comando.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        using var conexion = new MySqlConnection(_cadenaConexion);
        conexion.Open();

        using var comando = new MySqlCommand("DELETE FROM movimientos WHERE id = @id", conexion);
        comando.Parameters.AddWithValue("@id", id);
        comando.ExecuteNonQuery();
    }
}