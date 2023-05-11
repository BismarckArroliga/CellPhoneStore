using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Reportes
    {
        CD_Reportes objReportes = new CD_Reportes();

        public System.Data.DataTable ReportesProductos()
        {
            return objReportes.ReportesProductos();
        }
        public System.Data.DataTable ReportesCompras()
        {
            return objReportes.ReportesCompras();
        }
        public System.Data.DataTable ReportesVentas()
        {
            return objReportes.ReportesVentas();
        }
    }
}
