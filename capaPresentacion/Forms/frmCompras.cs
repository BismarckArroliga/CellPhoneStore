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
    public partial class frmCompras : Form
    {
        CN_Compras objCompras = new CN_Compras();
        CN_CacheUsuario objCacheUsuario = new CN_CacheUsuario();

        private void ListarTipoDocumento()
        {
            cmbDocumento.DataSource = objCompras.ListarTipoDocumento();
            cmbDocumento.DisplayMember = "Nombre";
            cmbDocumento.ValueMember = "Id";
        }

        private void TotalCompras()
        {
            txtNumCompras.Text = objCompras.TotalCompras().ToString();
        }

        public frmCompras()
        {
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            TotalCompras();
            ListarTipoDocumento();
        }

        private void ValidarDescuento(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtDescuento.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new md_proveedores())
            {
                var resul = modal.ShowDialog();

                if (resul == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal.Proveedor.IdProveedor;
                    txtNombre.Text = modal.Proveedor.Nombre;
                }
                else
                    txtIdProveedor.Select();
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new md_productosModal())
            {
                var resul = modal.ShowDialog();

                if (resul == DialogResult.OK)
                {
                    txtIdProducto.Text = modal.Productos.idProducto;
                    txtProducto.Text = modal.Productos.Nombre;
                    txtPrecioCosto.Text = modal.Productos.PrecioCosto;
                }
                else
                    txtIdProducto.Select();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool productoExiste = false;

            eliminarMensajeError();

            if (txtDescuento.Text == "")
            {
                txtDescuento.Text = "0";
            }

            if (ValidarCamposProducto() == false)
            {
                return;
            }

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.Cells["Producto_Id"].Value.ToString() == txtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if (productoExiste == false)
            {
                dgvProductos.Rows.Add(new object[] {
                    txtIdProducto.Text,
                    txtProducto.Text,
                    txtPrecioCosto.Text,
                    txtDescuento.Text,
                    txtCantidad.Value.ToString(),
                    ((txtCantidad.Value * Convert.ToDecimal(txtPrecioCosto.Text)) - Convert.ToDecimal(txtDescuento.Text)).ToString()
                });
                CalcularDescuento();
                CalcularTotal();
                LimpiarProducto();
            }  else
            {
                MessageBox.Show("El producto: " + txtProducto.Text + " ya esta agregado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarProducto();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarProducto();
        }

        private bool ValidarCamposProducto()
        {
            bool ok = true;

            if (txtProducto.Text == "")
            {
                ok = false;
                errorProvider.SetError(txtProducto, "Debes seleccionar un producto.");
            }
            return ok;

        }

        private void eliminarMensajeError()
        {
            errorProvider.SetError(txtProducto, "");
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            if (dgvProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value.ToString()); 
                }
                txtTotalAPagar.Text = total.ToString("0.00");
            }
        }

        private void CalcularDescuento()
        {
            decimal descuento = 0;
            if (dgvProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    descuento += Convert.ToDecimal(row.Cells["Descuento"].Value.ToString());
                }
                txtTotalDescuento.Text = descuento.ToString("0.00");
            }
        }
              
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (txtIdProveedor.Text == "")
            {
                MessageBox.Show("Debes ingresar un proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvProductos.Rows.Count < 1)
            {
                MessageBox.Show("Debes ingresar productos ala compra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable Detalle_Compra = new DataTable();
            Detalle_Compra.Columns.Add("Producto_Id", typeof(int));
            Detalle_Compra.Columns.Add("Cantidad", typeof(int));
            Detalle_Compra.Columns.Add("Costo", typeof(decimal));
            Detalle_Compra.Columns.Add("Descuento", typeof(decimal));
            Detalle_Compra.Columns.Add("Total", typeof(decimal));

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                Detalle_Compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["Producto_Id"].Value.ToString()),
                        Convert.ToInt32(row.Cells["Cantidad"].Value.ToString()),
                        Convert.ToDouble(row.Cells["Costo"].Value.ToString()),
                        Convert.ToDouble(row.Cells["Descuento"].Value.ToString()),
                        Convert.ToDouble(row.Cells["Total"].Value.ToString()),                        
                    }
                );
            }
            
            string documento_id = cmbDocumento.SelectedValue.ToString();
            string empleado_id = objCacheUsuario.Id.ToString();
            string proveedor_id = txtIdProveedor.Text;
            string total = txtTotalAPagar.Text; ;
            objCompras.InsertarCompra(documento_id, empleado_id, proveedor_id, total, Detalle_Compra);
            MessageBox.Show("Factura realizada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            TotalCompras();
            LimpiarCompra();    
            
        }

        private void LimpiarProducto()
        {
            txtIdProducto.Clear();
            txtProducto.Clear();
            txtPrecioCosto.Clear();
            txtDescuento.Text = "0.00";
            txtCantidad.Value = 1;
        }

        private void LimpiarCompra()
        {
            txtTotalAPagar.Text = "0.00";
            txtTotalDescuento.Text = "0.00";
            txtIdProveedor.Clear();
            txtNombre.Clear();
            dgvProductos.Rows.Clear();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "Delete")
            {
                int i = e.RowIndex;
                if (i != -1)
                {
                    dgvProductos.Rows.RemoveAt(i);
                    CalcularDescuento();
                    CalcularTotal();

                    if (dgvProductos.Rows.Count < 1)
                    {
                        txtTotalDescuento.Text = "0.00";
                        txtTotalAPagar.Text = "0.00";
                    }

                }
            }
        }

    }
}










