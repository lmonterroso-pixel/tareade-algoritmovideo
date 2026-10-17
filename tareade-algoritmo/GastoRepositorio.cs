using System.Collections.Generic;
using Microsoft.Data.SqlClient;

public class GastoRepositorio
{
    private const string cadenaConexion =
        @"Server=(localdb)\GastosTarea;Database=GastosDB;Integrated Security=True;";

    public void Insertar(Gasto gasto)
    {
        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            conexion.Open();

            string consulta =
                "INSERT INTO Gastos (Descripcion, Monto, Categoria) " +
                "VALUES (@descripcion, @monto, @categoria)";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue(
                    "@descripcion", gasto.Descripcion);
                comando.Parameters.AddWithValue(
                    "@monto", gasto.Monto);
                comando.Parameters.AddWithValue(
                    "@categoria", gasto.Categoria);

                comando.ExecuteNonQuery();
            }
        }
    }

    public List<Gasto> ListarTodos()
    {
        List<Gasto> lista = new List<Gasto>();

        using (SqlConnection conexion = new SqlConnection(cadenaConexion))
        {
            conexion.Open();

            string consulta =
                "SELECT Id, Descripcion, Monto, Categoria " +
                "FROM Gastos ORDER BY Id";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Gasto gasto = new Gasto();

                        gasto.Id = lector.GetInt32(0);
                        gasto.Descripcion = lector.GetString(1);
                        gasto.Monto = lector.GetDecimal(2);
                        gasto.Categoria = lector.GetString(3);

                        lista.Add(gasto);
                    }
                }
            }
        }

        return lista;
    }
}