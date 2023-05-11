using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class CD_DetalleVenta: CD_ConnectionString
    {
        public DataTable ListarDetalleVenta(int venta_id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_detalleVentas", sql))
                {
                    DataTable tabla = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@venta_id", venta_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    tabla.Load(reader);
                    return tabla;
                }
            }
        }
    }
}
