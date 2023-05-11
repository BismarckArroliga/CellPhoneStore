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
    public partial class frmVentas : Form
    {
        CN_Ventas objVentas = new CN_Ventas();
        CN_Estados objEstados = new CN_Estados();
        CN_CacheUsuario objCacheUsuario = new CN_CacheUsuario();
        CN_Productos objProdcutos = new CN_Productos();

        public frmVentas()
        {
            InitializeComponent();
        }

        private void ListarTipoDocumento()
        {
            cmbDocumento.DataSource = objVentas.ListarTipoDocumento();
            cmbDocumento.DisplayMember = "Nombre";
            cmbDocumento.ValueMember = "Id";
        }

        private void TotalVentas()
        {
            txtCantidadVenta.Text = objVentas.TotalVentas().ToString();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            TotalVentas();
            ListarTipoDocumento();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new md_clientes())
            {
                var resul = modal.ShowDialog();

                if (resul == DialogResult.OK)
                {
                    txtIdCliente.Text = modal.Clientes.idCliente;
                    txtNombre.Text = modal.Clientes.Nombre;
                }
                else
                    txtIdCliente.Select();
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
                    txtPrecioVenta.Text = modal.Productos.PrecioCosto;
                    txtStock.Text = modal.Productos.Stock;
                }
                else
                    txtIdCliente.Select();
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
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

            if (txtUnidades.Value > Convert.ToInt32(txtStock.Text))
            {
                MessageBox.Show("Las unidades no pueden superar al stock.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnidades.BackColor = Color.Red;
                txtUnidades.Select();
                return;
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
                txtUnidades.BackColor = Color.White;
                objProdcutos.RestarStock(txtIdProducto.Text, txtUnidades.Value.ToString());

                int stock = objEstados.StockActualProducto(txtIdProducto.Text);
                if (stock == 0)
                {
                    objEstados.ProductoInactivo(txtIdProducto.Text);
                }

                dgvProductos.Rows.Add(new object[] {
                    txtIdProducto.Text,
                    txtProducto.Text,
                    txtPrecioVenta.Text,
                    txtDescuento.Text,
                    txtUnidades.Value.ToString(),
                    ((txtUnidades.Value * Convert.ToDecimal(txtPrecioVenta.Text)) - Convert.ToDecimal(txtDescuento.Text)).ToString()
                });
                CalcularDescuento();
                CalcularTotal();
                LimpiarProducto();
            }
            else
            {
                MessageBox.Show("El producto: " + txtProducto.Text + " ya esta agregado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarProducto();
            }
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

        private void btnLimpiarProducto_Click(object sender, EventArgs e)
        {
            LimpiarProducto();
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

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "Delete")
            {
                int i = e.RowIndex;
                if (i != -1)
                {
                    string producto_id = dgvProductos.Rows[i].Cells["Producto_Id"].Value.ToString();
                    string unidades = dgvProductos.Rows[i].Cells["Unidades"].Value.ToString();

                    objProdcutos.SumarStock(producto_id, unidades);
                    int stock = objEstados.StockActualProducto(producto_id);
                    if (stock > 0)
                    {
                        objEstados.ProductoActivo(producto_id);
                    }

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

        private void LimpiarProducto()
        {
            txtIdProducto.Clear();
            txtProducto.Clear();
            txtStock.Text = "0";
            txtPrecioVenta.Text = "0.00";
            txtDescuento.Text = "0.00";
            txtUnidades.Value = 1;
        }

        private void LimpiarVenta()
        {
            txtIdCliente.Clear();
            txtNombre.Clear();
            dgvProductos.Rows.Clear();
            txtTotalDescuento.Text = "0.00";
            txtTotalAPagar.Text = "0.00";
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (txtIdCliente.Text == "")
            {
                MessageBox.Show("Debes seleccionar un cliente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvProductos.Rows.Count < 1)
            {
                MessageBox.Show("Debes ingresar productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable DetalleVenta = new DataTable();

            DetalleVenta.Columns.Add("Producto_Id", typeof(Int32));
            DetalleVenta.Columns.Add("Unidades", typeof(Int32));
            DetalleVenta.Columns.Add("Precio", typeof(decimal));
            DetalleVenta.Columns.Add("Descuento", typeof(decimal));
            DetalleVenta.Columns.Add("Total", typeof(decimal));

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                DetalleVenta.Rows.Add(new object[] {
                    row.Cells["Producto_Id"].Value.ToString(),
                    row.Cells["Unidades"].Value.ToString(),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Descuento"].Value.ToString(),
                    row.Cells["Total"].Value.ToString()
                });
            }

            string documento_id = cmbDocumento.SelectedValue.ToString();
            string empleado_id = objCacheUsuario.Id.ToString();
            string cliente_id = txtIdCliente.Text;
            string total = txtTotalAPagar.Text; ;
            objVentas.InsertarVenta(documento_id, empleado_id, cliente_id, total, DetalleVenta);
            MessageBox.Show("Factura realizada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            TotalVentas();
            LimpiarVenta();

        }
    }
}










