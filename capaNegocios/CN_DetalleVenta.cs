using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_DetalleVenta
    {
        CD_DetalleVenta objDetalleVenta = new CD_DetalleVenta();

        public System.Data.DataTable ListarDetalleVenta(string venta_id)
        {
            return objDetalleVenta.ListarDetalleVenta(Convert.ToInt32(venta_id));
        }

    }
}
