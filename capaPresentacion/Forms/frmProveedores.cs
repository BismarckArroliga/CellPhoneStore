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
    public partial class frmProveedores : Form
    {
        private bool btnPresionado = false;
        CN_Proveedores objProveedores = new CN_Proveedores();
        public frmProveedores()
        {
            InitializeComponent();           
        }

        private void ListarProveedores()
        {
            dgvProveedores.DataSource = objProveedores.ListarProveedores();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            ListarProveedores();
        }

        private void ValidarSoloNumero(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            btnPresionado = false;
            eliminarMensajeError();
            if (ValidarCamposVacios())
            {
                objProveedores.CrearProveedor(txtNombre.Text, txtRUC.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text);
                MessageBox.Show("Proveedor agregado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
                ListarProveedores();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnPresionado = true;
            eliminarMensajeError();
            if (ValidarCamposVacios())
            {
                var proveedorExiste = objProveedores.BuscarProveedor(txtIdProveedor.Text);

                if (proveedorExiste == false)
                {
                    MessageBox.Show("No se encontro ningún proveedor con el id: " + txtIdProveedor.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdProveedor.Clear();
                    return;
                }

                objProveedores.ActualizarProveedor(txtIdProveedor.Text,txtNombre.Text, txtRUC.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text);
                MessageBox.Show("Proveedor actualizado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
                ListarProveedores();
            }
        }

        private bool ValidarCamposVacios()
        {
            bool ok = true;
            if (txtNombre.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtNombre, "Campo obligatorio");
            }
            if (txtRUC.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtRUC, "Campo obligatorio");
            }
            if (txtTelefono.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtTelefono, "Campo obligatorio");
            }
            if (txtDireccion.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtDireccion, "Campo obligatorio");
            }
            if (txtEmail.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtEmail, "Campo obligatorio");
            }
            if (btnPresionado)
            {
                if (txtIdProveedor.Text == "")
                {
                    ok = false;
                    errorProvider.SetError(txtIdProveedor, "Campo obligatorio");
                }
            }
            return ok;
        }

        private void eliminarMensajeError()
        {           
            errorProvider.SetError(txtNombre, "");
            errorProvider.SetError(txtRUC, "");
            errorProvider.SetError(txtDireccion, "");
            errorProvider.SetError(txtTelefono, "");
            errorProvider.SetError(txtEmail, "");
            errorProvider.SetError(txtIdProveedor, "");          
        }
        private void LimpiarCampos()
        {
            eliminarMensajeError();
            txtNombre.Clear();
            txtRUC.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtIdProveedor.Clear();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

    }
}
