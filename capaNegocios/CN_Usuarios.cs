using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Usuarios
    {
        CD_Usuarios objUsuarios = new CD_Usuarios();

        public bool Login(string usuario, string contrasena)
        {
            return objUsuarios.Login(usuario, contrasena);
        }
        public void CrearUsuario(string usuario, string contrasena, string empleado_id)
        {
            objUsuarios.CrearUsuario(usuario, contrasena, Convert.ToInt32(empleado_id));
        }
        public void ActualizarUsuario(string usuario, string contrasena, string empleado_id)
        {
            objUsuarios.ActualizarUsuario(usuario, contrasena, Convert.ToInt32(empleado_id));
        }
        public bool BuscarUsuario(string empleado_id)
        {
            return objUsuarios.BuscarUsuario(Convert.ToInt32(empleado_id));
        }
    }
}
