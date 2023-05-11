using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Proveedores
    {
        CD_Proveedores objProveedores = new CD_Proveedores();

        public System.Data.DataTable ListarProveedores()
        {
            return objProveedores.ListarProveedores();
        }
        public void CrearProveedor(string nombre, string ruc, string direccion, string telefono, string email)
        {
            objProveedores.CrearProveedor(nombre, ruc, direccion, telefono, email);
        }
        public void ActualizarProveedor(string proveedor_id, string nombre, string ruc, string direccion, string telefono, string email)
        {
            objProveedores.ActualizarProveedor(Convert.ToInt32(proveedor_id), nombre, ruc, direccion, telefono, email);
        }
        public bool BuscarProveedor(string proveedor_id)
        {
            return objProveedores.BuscarProveedor(Convert.ToInt32(proveedor_id));
        }
    }
}
