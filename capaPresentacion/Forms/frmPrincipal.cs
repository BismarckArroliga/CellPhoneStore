using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocios;

namespace capaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CacheUsuario()
        {
            CN_CacheUsuario cache = new CN_CacheUsuario();
            lblUsuario.Text = cache.Nombre + " " + cache.Apellido;
            lblCargo.Text = cache.Cargo;
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CacheUsuario();
        }


        private void AbrirFormEnPanel(object FormHijo)
        {
            if (this.pnlContenedorForm.Controls.Count > 0)
                this.pnlContenedorForm.Controls.RemoveAt(0);

            Form form = FormHijo as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            this.pnlContenedorForm.Controls.Add(form);
            this.pnlContenedorForm.Tag = form;
            form.Show();
            form.BringToFront();
        }


        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmEmpleados());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmProductos());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmClientes());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmProveedores());
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmCompras());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmVentas());
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmFacturas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmReportes());
        }
    }
}
