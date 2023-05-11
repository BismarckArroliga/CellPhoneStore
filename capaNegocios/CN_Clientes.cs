using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Clientes
    {
        CD_Clientes objClientes = new CD_Clientes();

        public System.Data.DataTable ListarClientes()
        {
            return objClientes.ListarClientes();
        }
        public void InsertarClientes(string nombre, string apellido, string cedula)
        {
            objClientes.InsertarClientes(nombre, apellido, cedula);
        }
        public void ActualizarClientes(string idCliente, string nombre, string apellido, string cedula)
        {
            objClientes.ActualizarClientes(Convert.ToInt32(idCliente), nombre, apellido, cedula);
        }
        public bool BuscarCliente(string cliente_id)
        {
            return objClientes.BuscarCliente(Convert.ToInt32(cliente_id));
        }

    }
}
