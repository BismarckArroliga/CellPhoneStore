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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

namespace capaPresentacion
{
    public partial class frmReportes : Form
    {
        CN_Reportes objReportes = new CN_Reportes();

        public frmReportes()
        {
            InitializeComponent();
        }

        private void ReportesProductos()
        {
            dgvProductos.DataSource = objReportes.ReportesProductos();
        }

        private void ReportesCompras()
        {
            dgvCompras.DataSource = objReportes.ReportesCompras();
        }
        private void ReportesVentas()
        {
            dgvVentas.DataSource = objReportes.ReportesVentas();
        }
        private void frmReportes_Load(object sender, EventArgs e)
        {
            ReportesProductos();
            ReportesCompras();
            ReportesVentas();
        }

        private void btnImprimirProductos_Click(object sender, EventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardarProductos = new SaveFileDialog();
            guardarProductos.FileName = "Reporte de productos Activos.pdf";

            string pagina_html_texto = Properties.Resources.plantillaProductos.ToString();
            string filas = string.Empty;
            pagina_html_texto = pagina_html_texto.Replace("@Fecha", DateTime.Now.ToString("dd/MM/yyyy"));

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["ID"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Nombre"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Marca"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Descripcion"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCosto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioVenta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Stock"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Estado"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            pagina_html_texto = pagina_html_texto.Replace("@Filas", filas);

            if (guardarProductos.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardarProductos.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoDark, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(100, 80);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 80);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(pagina_html_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        private void btnImprimirCompras_Click(object sender, EventArgs e)
        {
            if (dgvCompras.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog guardarCompras = new SaveFileDialog();
            guardarCompras.FileName = "Reporte de compras del dia.pdf";

            string pagina_html_texto = Properties.Resources.plantillaCompras.ToString();
            string filas = string.Empty;
            pagina_html_texto = pagina_html_texto.Replace("@Fecha", DateTime.Now.ToString("dd/MM/yyyy"));

            double montoFinal = 0;
            foreach (DataGridViewRow row in dgvCompras.Rows)
            {

                filas += "<tr>";
                filas += "<td>" + row.Cells["Compra_id"].Value.ToString() + "</td>";
                filas += "<td>" + Convert.ToDateTime( row.Cells["Fecha"].Value).ToString("dd/MM/yyyy") + "</td>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Proveedor"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Costo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Descuento"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Total"].Value.ToString() + "</td>";
                filas += "</tr>";

                montoFinal += Convert.ToDouble(row.Cells["Total"].Value);
            }

            pagina_html_texto = pagina_html_texto.Replace("@MontoFinal", montoFinal.ToString("0.00"));
            pagina_html_texto = pagina_html_texto.Replace("@Filas", filas);

            if (guardarCompras.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardarCompras.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoDark, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(100, 80);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 80);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(pagina_html_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        private void btnImprimirVentas_Click(object sender, EventArgs e)
        {
            if (dgvVentas.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog guardarVentas = new SaveFileDialog();
            guardarVentas.FileName = "Reporte de ventas del dia.pdf";

            string pagina_html_texto = Properties.Resources.plantillaVentas.ToString();
            string filas = string.Empty;
            pagina_html_texto = pagina_html_texto.Replace("@Fecha", DateTime.Now.ToString("dd/MM/yyyy"));

            double montoFinal = 0;
            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Venta_id"].Value.ToString() + "</td>";
                filas += "<td>" + Convert.ToDateTime(row.Cells["FechaVenta"].Value).ToString("dd/MM/yyyy") + "</td>";
                filas += "<td>" + row.Cells["Cliente"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["ProductoVenta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["UnidadesVenta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["DescuentoVenta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["TotalVenta"].Value.ToString() + "</td>";
                filas += "</tr>";

                montoFinal += Convert.ToDouble(row.Cells["TotalVenta"].Value);
            }
            pagina_html_texto = pagina_html_texto.Replace("@MontoFinal", montoFinal.ToString("0.00"));
            pagina_html_texto = pagina_html_texto.Replace("@Filas", filas);

            if (guardarVentas.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardarVentas.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoDark, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(100, 80);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 80);
                    pdfDoc.Add(img);

                    using (StringReader sr = new StringReader(pagina_html_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }
    }
}
