using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocios;

namespace capaPresentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int
        wparam, int lparam);

        public void Mover()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            Mover();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtContrasena.Text != "")
                {
                    CN_Usuarios objUsuarios = new CN_Usuarios();
                    var usuario = objUsuarios.Login(txtUsuario.Text.Trim(), txtContrasena.Text.Trim());
                    if (usuario)
                    {
                        this.Hide();
                        frmPrincipal sistema = new frmPrincipal();
                        sistema.Show();
                        MessageBox.Show("Open");
                        sistema.FormClosed += login;
                    }
                    else
                        MessageBox.Show("Usuario o contraseña incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Debes ingresar una contraseña", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Debes ingresar un usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void login(object senderr, FormClosedEventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtUsuario.Select();
            this.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
