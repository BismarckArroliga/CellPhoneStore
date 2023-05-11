using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
   public class CD_Usuarios: CD_ConnectionString
    {
        // LOGIN PARA LOS USUARIOS
        public bool Login(string usuario, string contrasena)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_usuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "L");
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            CD_CacheUsuario.Id = reader.GetInt32(0);
                            CD_CacheUsuario.Nombre = reader.GetString(1);
                            CD_CacheUsuario.Apellido = reader.GetString(2);
                            CD_CacheUsuario.Cargo = reader.GetString(3);
                        }

                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
            }
        }

        public void CrearUsuario(string usuario, string contrasena, int empleado_id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_usuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "I");
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@empleado_Id", empleado_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarUsuario(string usuario, string contrasena, int empleado_id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_usuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "U");
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@empleado_Id", empleado_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool BuscarUsuario(int empleado_id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_usuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "B");
                    cmd.Parameters.AddWithValue("@empleado_Id", empleado_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

    }
}
