using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Ventas
    {
        CD_Ventas objVentas = new CD_Ventas();

        public System.Data.DataTable ListarTipoDocumento()
        {
            return objVentas.ListarTipoDocumento();
        }

        public System.Data.DataTable ListarVentas()
        {
            return objVentas.ListarVentas();
        }

        public void InsertarVenta(string documento_id, string empleado_id, string cliente_id, string total, System.Data.DataTable DetalleVenta)
        {
            objVentas.InsertarVentas(Convert.ToInt32(documento_id), Convert.ToInt32(empleado_id), Convert.ToInt32(cliente_id), Convert.ToDecimal(total), DetalleVenta);
        }
        public int TotalVentas()
        {
            return objVentas.TotalVentas();
        }

    }
}
