using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capaDatos
{
    public class CD_Compras : CD_ConnectionString
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

        public DataTable ListarCompras()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_compras", sql))
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

        public void InsertarCompra(int documento_id, int empleado_id, int proveedor_id, decimal total, DataTable DetalleCompra)
        {
            using (var sql = GetConnection())
            {
                sql.Open();

                using (var cmd = new SqlCommand("sp_compras", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "I");
                    cmd.Parameters.AddWithValue("@documento_Id", documento_id);
                    cmd.Parameters.AddWithValue("@empleado_Id", empleado_id);
                    cmd.Parameters.AddWithValue("@proveedor_Id", proveedor_id);
                    cmd.Parameters.AddWithValue("@total", total);                    
                    cmd.Parameters.AddWithValue("@detalleCompra", DetalleCompra);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int TotalCompras()
        {
            int count = 0;
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_compras", sql))
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
