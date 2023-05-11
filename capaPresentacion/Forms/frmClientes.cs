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
    public partial class frmClientes : Form
    {
        private bool btnPresionado = false;
        CN_Clientes objClientes = new CN_Clientes();

        public frmClientes()
        {
            InitializeComponent();           
        }

        private void ListarClientes()
        {
            dgvClientes.DataSource = objClientes.ListarClientes();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
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
                objClientes.InsertarClientes(txtNombre.Text, txtApellido.Text, txtCedula.Text);
                MessageBox.Show("Cliente registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
                ListarClientes();
            }
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            btnPresionado = true;
            eliminarMensajeError();
            if (ValidarCamposVacios())
            {
                var clienteExiste = objClientes.BuscarCliente(txtIdCliente.Text);

                if (clienteExiste == false)
                {
                    MessageBox.Show("No se encontro ningún cliente con el id: " + txtIdCliente.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdCliente.Clear();
                    return;
                }

                objClientes.ActualizarClientes(txtIdCliente.Text, txtNombre.Text, txtApellido.Text, txtCedula.Text);
                MessageBox.Show("Cliente actualizado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
                ListarClientes();
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
            if (txtApellido.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtApellido, "Campo obligatorio");
            }
            if (txtCedula.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtCedula, "Campo obligatorio");
            }
            if (btnPresionado)
            {
                if (txtIdCliente.Text == "")
                {
                    ok = false;
                    errorProvider.SetError(txtIdCliente, "Campo obligatorio");
                }
            }
            return ok;
        }

        private void eliminarMensajeError()
        {           
            errorProvider.SetError(txtNombre, "");
            errorProvider.SetError(txtApellido, "");
            errorProvider.SetError(txtCedula, "");
            errorProvider.SetError(txtIdCliente, "");
        }


        private void LimpiarCampos()
        {
            eliminarMensajeError();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtIdCliente.Clear();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

    }
}
