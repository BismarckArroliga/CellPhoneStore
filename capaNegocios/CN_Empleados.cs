using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Empleados
    {
        CD_Empleados objEmpleados = new CD_Empleados();

        public System.Data.DataTable ListarCargos()
        {
            return objEmpleados.ListarCargos();
        }
        public System.Data.DataTable ListarEmpleados()
        {
            return objEmpleados.ListarEmpleados();
        }
        public void InsertarEmpleado(string nombre, string apellido, string telefono, string direccion, string cedula, string cargo_Id)
        {
            objEmpleados.InsertarEmpleado(nombre, apellido, telefono, direccion, cedula, Convert.ToInt32(cargo_Id));
        }
        public void ActualizarEmpleado(string nombre, string apellido, string telefono, string direccion, string cedula, string cargo_Id, string empleado_id)
        {
            objEmpleados.ActualizarEmpleado(nombre, apellido, telefono, direccion, cedula, Convert.ToInt32(cargo_Id), Convert.ToInt32(empleado_id));
        }
        public bool BuscarEmpleado(string empleado_id)
        {
            return objEmpleados.BuscarEmpleado(Convert.ToInt32(empleado_id));
        }

    }
}
