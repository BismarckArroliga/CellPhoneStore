using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class CD_Estados: CD_ConnectionString
    {
        public int StockActualProducto(int producto_id)
        {
            int stock = 0;

            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_estados", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "S");
                    cmd.Parameters.AddWithValue("@producto_id", producto_id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                           stock = reader.GetInt32(0);
                        }
                    }
                    return stock;
                }
            }
        }
        public void ProductoActivo(int producto_id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_estados", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "A");
                    cmd.Parameters.AddWithValue("@producto_id", producto_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ProductoInactivo(int producto_id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_estados", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "I");
                    cmd.Parameters.AddWithValue("@producto_id", producto_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
