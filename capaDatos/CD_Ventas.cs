using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class CD_Ventas: CD_ConnectionString
    {
        public DataTable ListarTipoDocumento()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_tipoDocumento", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tabla = new DataTable();
                    tabla.Load(reader);
                    return tabla;
                }
            }
        }

        public DataTable ListarVentas()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_ventas", sql))
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

        public void InsertarVentas(int documento_id, int empleado_id, int cliente_id, decimal total, DataTable DetalleVenta)
        {
            using (var sql = GetConnection())
            {
                sql.Open();

                using (var cmd = new SqlCommand("sp_ventas", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "I");
                    cmd.Parameters.AddWithValue("@documento_Id", documento_id);
                    cmd.Parameters.AddWithValue("@empleado_Id", empleado_id);
                    cmd.Parameters.AddWithValue("@cliente_Id", cliente_id);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@detalleVenta", DetalleVenta);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int TotalVentas()
        {
            int count = 0;
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_ventas", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "T");
                    count += Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
        }

    }
}
