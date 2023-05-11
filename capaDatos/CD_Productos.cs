using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace capaDatos
{
   public class CD_Productos: CD_ConnectionString
    {
        public DataTable ListarProductos()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_productos", sql))
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

        public DataTable ListarEstados()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_productos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "E");
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tabla = new DataTable();
                    tabla.Load(reader);
                    return tabla;
                }
            }
        }

        public void InsertarProductos(string nombre, string marca, string descripcion, decimal precioCosto, decimal precioVenta, int estado_Id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_productos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "I");
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@precioCosto", precioCosto);
                    cmd.Parameters.AddWithValue("@precioVenta", precioVenta);
                    cmd.Parameters.AddWithValue("@estado_Id", estado_Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarProductos(int idProducto, string nombre, string marca, string descripcion, decimal precioCosto, decimal precioVenta, int estado_Id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_productos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "U");
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@precioCosto", precioCosto);
                    cmd.Parameters.AddWithValue("@precioVenta", precioVenta);
                    cmd.Parameters.AddWithValue("@estado_Id", estado_Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool BuscarProducto(int producto_id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_productos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "B");
                    cmd.Parameters.AddWithValue("@id", producto_id);
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

        public void RestarStock(int idProducto, int unidades)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_productos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "R");
                    cmd.Parameters.AddWithValue("@id", idProducto);                    
                    cmd.Parameters.AddWithValue("@unidades",unidades);                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SumarStock(int idProducto, int unidades)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_productos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "S");
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    cmd.Parameters.AddWithValue("@unidades", unidades);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
