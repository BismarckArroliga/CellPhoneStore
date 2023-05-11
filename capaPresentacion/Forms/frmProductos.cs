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
    public partial class frmProductos : Form
    {
        private bool btnPresionado = false;

        CN_Productos objProductos = new CN_Productos();

        public frmProductos()
        {
            InitializeComponent();           
        }

        private void ListarProductos()
        {
            dgvProductos.DataSource = objProductos.ListarProductos();
        }
        private void ListarEstados()
        {
            cmbEstados.DataSource = objProductos.ListarEstados();
            cmbEstados.DisplayMember = "Nombre";
            cmbEstados.ValueMember = "Id";
        }
        private void frmProductos_Load(object sender, EventArgs e)
        {
            ListarEstados();
            ListarProductos();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            btnPresionado = false;
            eliminarMensajeError();
            if (ValidarCamposVacios())
            {
                objProductos.InsertarProductos(txtNombre.Text, txtMarca.Text, txtDescripcion.Text, txtPrecioCosto.Text, txtPrecioVenta.Text, cmbEstados.SelectedValue.ToString());
                MessageBox.Show("Producto registrado correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
                ListarProductos();

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnPresionado = true;
            eliminarMensajeError();
            if (ValidarCamposVacios())
            {
                var productoExiste = objProductos.BuscarProducto(txtIdProducto.Text);

                if (productoExiste == false)
                {
                    MessageBox.Show("No se encontro ningún producto con el id: " + txtIdProducto.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdProducto.Clear();
                    return;
                }

                objProductos.ActualizarProductos(txtIdProducto.Text, txtNombre.Text, txtMarca.Text, txtDescripcion.Text, txtPrecioCosto.Text, txtPrecioVenta.Text, cmbEstados.SelectedValue.ToString());
                MessageBox.Show("Producto actualizado correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                LimpiarCampos();
                ListarProductos();
                
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
            if (txtMarca.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtMarca, "Campo obligatorio");
            }
            if (txtDescripcion.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtDescripcion, "Campo obligatorio");
            }
            if (txtPrecioCosto.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtPrecioCosto, "Campo obligatorio");
            }
            if (txtPrecioVenta.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtPrecioVenta, "Campo obligatorio");
            }

            if (btnPresionado)
            {
                if (txtIdProducto.Text == "")
                {
                    ok = false;
                    errorProvider.SetError(txtIdProducto, "Campo obligatorio");
                }
            }

            return ok;
        }

        private void eliminarMensajeError()
        {
            errorProvider.SetError(txtIdProducto, "");
            errorProvider.SetError(txtNombre, "");
            errorProvider.SetError(txtMarca, "");
            errorProvider.SetError(txtDescripcion, "");
            errorProvider.SetError(txtPrecioCosto, "");
            errorProvider.SetError(txtPrecioVenta, "");          
        }

        private void ValidarPrecios(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            } else
            {
                if (txtPrecioCosto.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                } else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    } else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtIdProducto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void LimpiarCampos()
        {
            txtIdProducto.Clear();
            txtNombre.Clear();
            txtMarca.Clear();
            txtDescripcion.Clear();
            txtPrecioCosto.Clear();
            txtPrecioVenta.Clear();
            cmbEstados.SelectedValue = 1;
        }

        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            eliminarMensajeError();
            LimpiarCampos();  
        }

        
    }
}
















