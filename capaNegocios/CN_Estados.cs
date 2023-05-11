using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Estados
    {
        CD_Estados objEstados = new CD_Estados();

        public int StockActualProducto(string producto_id)
        {
            return objEstados.StockActualProducto(Convert.ToInt32(producto_id));
        }
        public void ProductoActivo(string producto_id)
        {
            objEstados.ProductoActivo(Convert.ToInt32(producto_id));
        }
        public void ProductoInactivo(string producto_id)
        {
            objEstados.ProductoInactivo(Convert.ToInt32(producto_id));
        }
    }
}
