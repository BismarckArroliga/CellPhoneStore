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
    public partial class md_clientes : Form
    {
        CN_Clientes objClientes = new CN_Clientes();
        public Clientes Clientes { get; set; }

        public md_clientes()
        {
            InitializeComponent();
        }

        private void ListarClientes()
        {
            dgvClientes.DataSource = objClientes.ListarClientes();
        }

        private void md_clientes_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;

            if (e.RowIndex != -1)
            {
                Clientes = new Clientes();
                Clientes.idCliente = dgvClientes.Rows[iRow].Cells["Id"].Value.ToString();
                Clientes.Nombre = dgvClientes.Rows[iRow].Cells["Nombre"].Value.ToString() + " " + dgvClientes.Rows[iRow].Cells["Apellido"].Value.ToString();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}




