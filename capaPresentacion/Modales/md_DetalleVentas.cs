using capaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class md_DetalleVentas : Form
    {
        public md_DetalleVentas()
        {
            InitializeComponent();
        }

        public int _idVenta { get; set; }

        private void listarDetalleVenta()
        {
            CN_DetalleVenta objDetalleCompras = new CN_DetalleVenta();
            dgvVentas.DataSource = objDetalleCompras.ListarDetalleVenta(_idVenta.ToString());
        }

        private void md_DetalleVentas_Load(object sender, EventArgs e)
        {
            listarDetalleVenta();
        }
    }
}
