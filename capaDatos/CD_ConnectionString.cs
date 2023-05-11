using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace capaDatos
{
    public abstract class CD_ConnectionString
    {
        private readonly string sql;
        
        public CD_ConnectionString()
        {
            sql = "Data Source=(local);Initial Catalog=BD_CellPhoneStore;Integrated Security=True";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(sql);
        }
         
    }
}
