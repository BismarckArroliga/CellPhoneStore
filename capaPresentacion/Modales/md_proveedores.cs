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
    public partial class md_proveedores : Form
    {
        public Proveedor Proveedor { get; set; }
        CN_Proveedores objProveedores = new CN_Proveedores();

        public md_proveedores()
        {
            InitializeComponent();
        }

        private void ListarProveedores()
        {
            dgvProveedores.DataSource = objProveedores.ListarProveedores();
        }

        private void md_proveedores_Load(object sender, EventArgs e)
        {
            ListarProveedores();
        }

        private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;

            if (e.RowIndex != -1)
            {
                Proveedor = new Proveedor();
                Proveedor.IdProveedor = dgvProveedores.Rows[iRow].Cells["Id"].Value.ToString();
                Proveedor.Nombre = dgvProveedores.Rows[iRow].Cells["Nombre"].Value.ToString();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}




