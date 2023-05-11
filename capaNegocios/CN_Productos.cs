using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Productos
    {
        CD_Productos objProductos = new CD_Productos();

        public System.Data.DataTable ListarProductos()
        {
            return objProductos.ListarProductos();
        }
        public System.Data.DataTable ListarEstados()
        {
            return objProductos.ListarEstados();
        }
        public void InsertarProductos(string nombre, string marca, string descripcion, string precioCosto, string precioVenta, string estado_Id)
        {
            objProductos.InsertarProductos(nombre, marca, descripcion, Convert.ToDecimal(precioCosto), Convert.ToDecimal(precioVenta), Convert.ToInt32(estado_Id));
        }
        public void ActualizarProductos(string idProducto, string nombre, string marca, string descripcion, string precioCosto, string precioVenta, string estado_Id)
        {
            objProductos.ActualizarProductos(Convert.ToInt32(idProducto), nombre, marca, descripcion, Convert.ToDecimal(precioCosto), Convert.ToDecimal(precioVenta), Convert.ToInt32(estado_Id));
        }
        public bool BuscarProducto(string producto_id)
        {
            return objProductos.BuscarProducto(Convert.ToInt32(producto_id));
        }
        public void RestarStock(string idProducto, string unidades)
        {
            objProductos.RestarStock(Convert.ToInt32(idProducto), Convert.ToInt32(unidades));
        }
        public void SumarStock(string idProducto, string unidades)
        {
            objProductos.SumarStock(Convert.ToInt32(idProducto), Convert.ToInt32(unidades));
        }
    }
}
