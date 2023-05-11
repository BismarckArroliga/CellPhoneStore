using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
   public class CD_Reportes: CD_ConnectionString
    {
        public DataTable ReportesProductos()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_reportes", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "P");
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tabla = new DataTable();
                    tabla.Load(reader);
                    return tabla;
                }
            }
        }

        public DataTable ReportesCompras()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_reportes", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "C");
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tabla = new DataTable();
                    tabla.Load(reader);
                    return tabla;
                }
            }
        }

        public DataTable ReportesVentas()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_reportes", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "V");
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tabla = new DataTable();
                    tabla.Load(reader);
                    return tabla;
                }
            }
        }
    }
}
