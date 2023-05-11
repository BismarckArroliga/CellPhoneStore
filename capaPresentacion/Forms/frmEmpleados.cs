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

    public partial class frmEmpleados : Form
    {
        private bool btnPresionadoEmpleado = false;
        CN_Empleados objEmpleados = new CN_Empleados();
        CN_Usuarios objUsuarios = new CN_Usuarios();

        public frmEmpleados()
        {
            InitializeComponent();           
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            ListarCargos();
            ListarEmpleados();
        }

        private void ListarCargos()
        {
            cmbCargos.DataSource = objEmpleados.ListarCargos();
            cmbCargos.DisplayMember = "Nombre";
            cmbCargos.ValueMember = "Id";
        }

        private void ListarEmpleados()
        {
            dgvEmpleados.DataSource = objEmpleados.ListarEmpleados();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            btnPresionadoEmpleado = false;
            eliminarMensajeError();
            if (ValidarCamposEmpleados())
            {             
                objEmpleados.InsertarEmpleado(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, txtCedula.Text, cmbCargos.SelectedValue.ToString());
                MessageBox.Show("Empleado registrado correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
                ListarEmpleados();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnPresionadoEmpleado = true;
            eliminarMensajeError();
            if (ValidarCamposEmpleados())
            {
                var empleadoExiste = objEmpleados.BuscarEmpleado(txtIdEmpleado.Text);

                if (empleadoExiste == false)
                {
                    MessageBox.Show("No se encontro ningún empleado con el id: " + txtIdEmpleado.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdEmpleado.Clear();
                    return;
                }

                objEmpleados.ActualizarEmpleado(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, txtCedula.Text, cmbCargos.SelectedValue.ToString(), txtIdEmpleado.Text);
                MessageBox.Show("Empleado actualizado correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
                ListarEmpleados();
            }
        }

        private void btnIngresarUsuario_Click(object sender, EventArgs e)
        {         
            eliminarMensajeError();
            if (ValidarCamposUsuario())
            {
                var usuarioExiste = objUsuarios.BuscarUsuario(txtIdEmpleado.Text);
                var empleadoExiste = objEmpleados.BuscarEmpleado(txtIdEmpleado.Text);

                if (usuarioExiste)
                {
                    MessageBox.Show("Este empleado ya tiene un usuario asignado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtIdEmpleado.Clear();
                    return;
                }

                if (empleadoExiste == false)
                {
                    MessageBox.Show("No se encontro ningún empleado con el id: " + txtIdEmpleado.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtIdEmpleado.Clear();
                    return;
                }

                objUsuarios.CrearUsuario(txtUsuario.Text.Trim(), txtContrasena.Text.Trim(), txtIdEmpleado.Text);
                MessageBox.Show("Usuario creado correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
            }
        }

        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            eliminarMensajeError();
            if (ValidarCamposUsuario())
            {
                var empleadoExiste = objEmpleados.BuscarEmpleado(txtIdEmpleado.Text);

                if (empleadoExiste == false)
                {
                    MessageBox.Show("No se encontro ningún empleado con el id: " + txtIdEmpleado.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtIdEmpleado.Clear();
                    return;
                }

                objUsuarios.ActualizarUsuario(txtUsuario.Text.Trim(), txtContrasena.Text.Trim(), txtIdEmpleado.Text);
                MessageBox.Show("Usuario actualizado correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
            }
        }
      
        private bool ValidarCamposEmpleados()
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
            if (txtCedula.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtCedula, "Campo obligatorio");
            }

            if (btnPresionadoEmpleado)
            {
                if (txtIdEmpleado.Text == "")
                {
                    ok = false;
                    errorProvider.SetError(txtIdEmpleado, "Campo obligatorio");
                }
            }

            return ok;
        }

 
        private bool ValidarCamposUsuario()
        {
            bool ok = true;

            if (txtUsuario.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtUsuario, "Campo obligatorio");
            }

            if (txtContrasena.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtContrasena, "Campo obligatorio");
            }

            if (txtIdEmpleado.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtIdEmpleado, "Campo obligatorio");
            }

            return ok;
        }

        private void eliminarMensajeError()
        {
            errorProvider.SetError(txtNombre, "");
            errorProvider.SetError(txtApellido, "");
            errorProvider.SetError(txtTelefono, "");
            errorProvider.SetError(txtDireccion, "");
            errorProvider.SetError(txtCedula, "");
            errorProvider.SetError(txtUsuario, "");
            errorProvider.SetError(txtContrasena, "");           
            errorProvider.SetError(txtIdEmpleado, "");
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

        private void dgvEmpleados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.RowIndex;

            if (i >= 0)
            {
                txtUsuario.Text = dgvEmpleados.Rows[i].Cells["Nombre"].Value.ToString();
                txtIdEmpleado.Text = dgvEmpleados.Rows[i].Cells["Id"].Value.ToString();
                txtContrasena.Select();
            }
        }


        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCedula.Clear();
            cmbCargos.SelectedValue = 1;
            txtIdEmpleado.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            eliminarMensajeError();
            LimpiarCampos();
        }
    }
}
