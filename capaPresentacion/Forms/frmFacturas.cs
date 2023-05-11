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
    public partial class frmFacturas : Form
    {
        CN_Compras objCompras = new CN_Compras();
        CN_Ventas objVentas = new CN_Ventas();

        public frmFacturas()
        {
            InitializeComponent();
        }

        private void ListarCompras()
        {
            dgvCompras.DataSource = objCompras.ListarCompras();
        }

        private void ListarVentas()
        {
            dgvVentas.DataSource = objVentas.ListarVentas();
        }

        private void frmFacturas_Load(object sender, EventArgs e)
        {
            ListarCompras();
            ListarVentas();
        }

        private void btnDetalleCompras_Click(object sender, EventArgs e)
        {
            if (dgvCompras.Rows.Count == 0)
            {
                MessageBox.Show("Primero debes facturar una Compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var modalDetalleCompras = new md_DetalleCompra())
            {
                // CENTRAR MODAL ESTUDIANTES
                Point pnlLocation = pnlFondo.PointToScreen(pnlFondo.Location);
                int x = pnlLocation.X + (pnlFondo.Width / 2) - (modalDetalleCompras.Width / 2);
                int y = pnlLocation.Y + (pnlFondo.Height / 2) - (modalDetalleCompras.Height / 2);
                modalDetalleCompras.Location = new Point(x, y);

                modalDetalleCompras._idCompra = Convert.ToInt32(this.dgvCompras.CurrentRow.Cells["compra_id"].Value);
                modalDetalleCompras.ShowDialog();
            }
        }

        private void btnDetalleVentas_Click(object sender, EventArgs e)
        {
            if (dgvVentas.Rows.Count == 0)
            {
                MessageBox.Show("Primero debes facturar una Compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var modalDetalleVentas = new md_DetalleVentas())
            {
                // CENTRAR MODAL ESTUDIANTES
                Point pnlLocation = pnlFondo.PointToScreen(pnlFondo.Location);
                int x = pnlLocation.X + (pnlFondo.Width / 2) - (modalDetalleVentas.Width / 2);
                int y = pnlLocation.Y + (pnlFondo.Height / 2) - (modalDetalleVentas.Height / 2);
                modalDetalleVentas.Location = new Point(x, y);

                modalDetalleVentas._idVenta = Convert.ToInt32(this.dgvVentas.CurrentRow.Cells["venta_id"].Value);
                modalDetalleVentas.ShowDialog();
            }
        }
    }
}
