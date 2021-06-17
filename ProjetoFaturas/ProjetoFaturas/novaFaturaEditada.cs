using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Core;
using System.IO;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Pdfa;

namespace ProjetoFaturas
{
    
    
    public partial class novaFaturaEditada : Form
    {
        string connectionString = @"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127";

        public novaFaturaEditada()
        {
            InitializeComponent();

        }

        private void novaFaturaEditada_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Nome.Text == "" || Morada.Text == "" || Telefone.Text == "")
            {
                MessageBox.Show(" Alguns campos obrigatórios não estão preenchidos.", " Erro! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand cmdCliente = new SqlCommand("insert into cliente (Nome, Morada, Telefone, Password) values (@Nome, @Morada, @Telefone, @Password) select scope_identity()", sqlCon);
                    SqlCommand cmdProdutos = new SqlCommand("insert into produtos (Quantidade, Descricao, Montante, cliente_ID) values(@Quantidade, @Descricao, @Montante, @ID) select scope_identity()", sqlCon);
                    SqlCommand cmdPedido = new SqlCommand("insert into pedido (Total, data_pedido, ID_produtos, ID_cliente) values(@Total, @Data, @IDprodutos, @ID_cliente) ", sqlCon);             
                    cmdCliente.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = Nome.Text;
                    cmdCliente.Parameters.Add("@Morada", SqlDbType.VarChar, 50).Value = Morada.Text;
                    cmdCliente.Parameters.Add("@Telefone", SqlDbType.VarChar, 50).Value = Telefone.Text;
                    cmdCliente.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password.Text;
                    cmdPedido.Parameters.Add("@Data", SqlDbType.Date).Value = Data.Text;
                    sqlCon.Open();
                    SqlCommand sqlID = new SqlCommand("select max(IDcliente) from cliente", sqlCon);
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        cmdProdutos.Parameters.Add("@Quantidade", SqlDbType.Int).Value = dataGridView1.Rows[i].Cells["Quantidade"].Value;
                        cmdProdutos.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells["Descricao"].Value;
                        cmdProdutos.Parameters.Add("@Montante", SqlDbType.Money).Value = dataGridView1.Rows[i].Cells["Montante"].Value;
                        cmdPedido.Parameters.Add("@Total", SqlDbType.Money).Value = dataGridView1.Rows[i].Cells["Total"].Value;

                        
                        int IDcliente = Convert.ToInt32(sqlID.ExecuteScalar());
                        cmdProdutos.Parameters.Add("@ID", SqlDbType.Int).Value = IDcliente;
                        

                    }
                    SqlCommand sqlIDproduto = new SqlCommand("select max(IDprodutos) from produtos", sqlCon);
                    var IDprodutos = sqlIDproduto.ExecuteScalar();
                    if (!(IDprodutos is DBNull))
                        IDprodutos = Convert.ToInt32(sqlIDproduto.ExecuteScalar());
                    cmdPedido.Parameters.Add("@IDprodutos", SqlDbType.Int).Value = IDprodutos;

                    int ID_cliente = Convert.ToInt32(sqlID.ExecuteScalar());
                    cmdPedido.Parameters.Add("@ID_cliente", SqlDbType.Int).Value = ID_cliente;

                    cmdCliente.ExecuteScalar();
                    cmdProdutos.ExecuteScalar();
                    cmdPedido.ExecuteNonQuery();
                    MessageBox.Show(" Emitida com sucesso.", " Sucesso! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[dataGridView1.Columns["totalsIVA"].Index].Value = Convert.ToString((Convert.ToDouble(row.Cells[dataGridView1.Columns["Quantidade"].Index].Value)) * (Convert.ToDouble(row.Cells[dataGridView1.Columns["Montante"].Index].Value)));
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[dataGridView1.Columns["Total"].Index].Value = Convert.ToString((Convert.ToDouble(row.Cells[dataGridView1.Columns["TotalsIva"].Index].Value) * 0.23) + Convert.ToDouble(row.Cells[dataGridView1.Columns["TotalsIva"].Index].Value));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                        this.dataGridView1.DataSource = null;
                        this.dataGridView1.Rows.Clear();
                    }
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            try
            {
                List<Orders> orders = new List<Orders>();

                orders.Add(new Orders { productId = 1045, product = "Acer Aspire E575", price = 45999, qty = 1 });
                orders.Add(new Orders { productId = 7561, product = "Logitech", price = 799, qty = 2 });
                orders.Add(new Orders { productId = 5785, product = "Logitech MK270r", price = 1599, qty = 1 });

                string filePath = @"D:\WinForms\MyWinFormsApp\MyWinFormsApp\PDFResources\sRGB_CS_profile.icm";
                string fontFile = @"D:\WinForms\MyWinFormsApp\MyWinFormsApp\PDFResources\FreeSans.ttf";
                string fileName = @"D:\WinForms\MyWinFormsApp\MyWinFormsApp\files\sample" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ".pdf";

                PdfADocument pdf = new PdfADocument(
                new PdfWriter(fileName),
                PdfAConformanceLevel.PDF_A_1B,
                new PdfOutputIntent("Custom", "", "http://www.color.org", "sRGB IEC61966-2.1",
                new FileStream(filePath, FileMode.Open, FileAccess.Read)));

                PdfFont font = PdfFontFactory.CreateFont(fontFile, PdfEncodings.WINANSI,
                PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
                Document document = new Document(pdf);

                document.SetFont(font);

                Paragraph header = new Paragraph("ORDER DETAIL").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
                document.Add(header);

                Paragraph subheader = new Paragraph("C# WINDOWS FORM CREATE PDF DOCUMENT USING iTEXT7 LIBRARY").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10);
                document.Add(subheader);

                LineSeparator ls = new LineSeparator(new SolidLine());
                document.Add(ls);

                Paragraph sellerHeader = new Paragraph("Sold by:").SetBold().SetTextAlignment(TextAlignment.LEFT);
                Paragraph sellerDetail = new Paragraph("Seller Company").SetTextAlignment(TextAlignment.LEFT);
                Paragraph sellerAddress = new Paragraph("Mumbai, Maharashtra India").SetTextAlignment(TextAlignment.LEFT);
                Paragraph sellerContact = new Paragraph("+91 1000000000").SetTextAlignment(TextAlignment.LEFT);

                document.Add(sellerHeader);
                document.Add(sellerDetail);
                document.Add(sellerAddress);
                document.Add(sellerContact);

                Paragraph customerHeader = new Paragraph("Customer details:").SetBold().SetTextAlignment(TextAlignment.RIGHT);
                Paragraph customerDetail = new Paragraph("Customer ABC").SetTextAlignment(TextAlignment.RIGHT);
                Paragraph customerAddress1 = new Paragraph("R783, Rose Apartments, Santacruz (E)").SetTextAlignment(TextAlignment.RIGHT);
                Paragraph customerAddress2 = new Paragraph("Mumbai 400054, Maharashtra India").SetTextAlignment(TextAlignment.RIGHT);

                Paragraph customerContact = new Paragraph("+91 0000000000").SetTextAlignment(TextAlignment.RIGHT);

                document.Add(customerHeader);
                document.Add(customerDetail);
                document.Add(customerAddress1);
                document.Add(customerAddress2);
                document.Add(customerContact);

                Paragraph orderNo = new Paragraph("Order No:15484659").SetBold().SetTextAlignment(TextAlignment.LEFT);
                Paragraph invoiceNo = new Paragraph("Invoice No:MH-MU-1077").SetTextAlignment(TextAlignment.LEFT);
                Paragraph invoiceTimestamp = new Paragraph("Date: 30/05/2021 04:25:37 PM").SetTextAlignment(TextAlignment.LEFT);

                document.Add(orderNo);
                document.Add(invoiceNo);
                document.Add(invoiceTimestamp);

                Table table = new Table(5, true);

                table.SetFontSize(9);
                Cell headerProductId = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Code"));
                Cell headerProduct = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Product"));
                Cell headerProductPrice = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Price"));
                Cell headerProductQty = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Qty"));
                Cell headerTotal = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Total"));

                table.AddCell(headerProductId);
                table.AddCell(headerProduct);
                table.AddCell(headerProductPrice);
                table.AddCell(headerProductQty);
                table.AddCell(headerTotal);

                double grandTotalVal = 0;
                foreach (Orders c in orders)
                {
                    Cell productid = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(c.productId.ToString()));
                    Cell product = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(c.product));
                    Cell price = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(c.price.ToString()));
                    Cell qty = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(c.qty.ToString()));
                    var value = c.price * c.qty;
                    Cell total = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(value.ToString()));

                    grandTotalVal += value;
                    table.AddCell(productid);
                    table.AddCell(product);
                    table.AddCell(price);
                    table.AddCell(qty);
                    table.AddCell(total);
                }

                Cell grandTotalHeader = new Cell(1, 4).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Total: "));
                Cell grandTotal = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(" " + grandTotalVal.ToString()));

                table.AddCell(grandTotalHeader);
                table.AddCell(grandTotal);

                document.Add(table);
                table.Flush();
                table.Complete();
                document.Close();

                System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception ex)
            {

            }

        }
    }

}

