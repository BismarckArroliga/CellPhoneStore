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
    public partial class md_DetalleCompra : Form
    {
        public md_DetalleCompra()
        {
            InitializeComponent();
        }

        public int _idCompra { get; set; }

        private void listarDetalleCompra()
        {
            CN_DetalleCompra objDetalleCompras = new CN_DetalleCompra();
            dgvCompra.DataSource = objDetalleCompras.ListarDetalleCompra(_idCompra.ToString());
        }

        private void md_DetalleCompra_Load(object sender, EventArgs e)
        {
            listarDetalleCompra();
        }
    }
}
