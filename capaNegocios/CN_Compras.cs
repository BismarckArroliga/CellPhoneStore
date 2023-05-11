using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Compras
    {
        CD_Compras objCompras = new CD_Compras();

        public System.Data.DataTable ListarTipoDocumento()
        {
            return objCompras.ListarTipoDocumento();
        }
        public void InsertarCompra(string documento_id, string empleado_id, string proveedor_id, string total, System.Data.DataTable DetalleCompra)
        {
            objCompras.InsertarCompra(Convert.ToInt32(documento_id), Convert.ToInt32(empleado_id), Convert.ToInt32(proveedor_id), Convert.ToDecimal(total), DetalleCompra);
        }

        public System.Data.DataTable ListarCompras()
        {
            return objCompras.ListarCompras();
        }


        public int TotalCompras()
        {
            return objCompras.TotalCompras();
        }

    }
}
