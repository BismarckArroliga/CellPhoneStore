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
    public partial class md_productosModal : Form
    {
        public Productos Productos { get; set; }
        CN_Productos objProductos = new CN_Productos();

        public md_productosModal()
        {
            InitializeComponent();
        }

        private void ListarProductos()
        {
            dgvProductos.DataSource = objProductos.ListarProductos();
        }
     
        private void md_productos_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;

            if (e.RowIndex != -1)
            {
                Productos = new Productos();
                Productos.idProducto = dgvProductos.Rows[iRow].Cells["Id"].Value.ToString();
                Productos.Nombre = dgvProductos.Rows[iRow].Cells["Nombre"].Value.ToString();
                Productos.PrecioCosto = dgvProductos.Rows[iRow].Cells["precioCosto"].Value.ToString();
                Productos.PrecioVenta = dgvProductos.Rows[iRow].Cells["precioVenta"].Value.ToString();
                Productos.Stock = dgvProductos.Rows[iRow].Cells["Stock"].Value.ToString();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}




