using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_DetalleCompra
    {
        CD_DetalleCompra objDetalleCompra = new CD_DetalleCompra();
        public System.Data.DataTable ListarDetalleCompra(string compra_id)
        {
            return objDetalleCompra.ListarDetalleCompra(Convert.ToInt32(compra_id));
        }

    }
}
