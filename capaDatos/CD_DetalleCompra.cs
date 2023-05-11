using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class CD_DetalleCompra: CD_ConnectionString
    {
        public DataTable ListarDetalleCompra(int compra_id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_detalleCompras", sql))
                {
                    DataTable tabla = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@compra_id", compra_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    tabla.Load(reader);
                    return tabla;
                }
            }
        }
    }
}
