using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace capaDatos
{
    public class CD_Clientes: CD_ConnectionString
    {
        public DataTable ListarClientes()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_clientes", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "L");
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tabla = new DataTable();
                    tabla.Load(reader);
                    return tabla;
                }
            }
        }

        public void InsertarClientes(string nombre, string apellido, string cedula)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_clientes", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "I");
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarClientes(int idCliente, string nombre, string apellido, string cedula)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_clientes", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "U");
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool BuscarCliente(int cliente_id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_clientes", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "B");
                    cmd.Parameters.AddWithValue("@id", cliente_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }


    }
}
