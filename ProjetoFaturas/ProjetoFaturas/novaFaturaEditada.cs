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
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjetoFaturas
{
    
    public partial class novaFaturaEditada : Form
    {
        string connectionString = @"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127";
        public novaFaturaEditada()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void novaFaturaEditada_Load(object sender, EventArgs e)
        {
            //using (SqlConnection sqlCon = new SqlConnection(connectionString))
            //{
            //    SqlCommand sqlID = new SqlCommand("select max(IDcliente) from cliente", sqlCon);
            //    sqlCon.Open();
            //    int IDcliente = Convert.ToInt32(sqlID.ExecuteScalar());
            //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //        dataGridView1.Rows[i].Cells["ID"].Value = IDcliente;

            //    //guardar IDcliente numa variavel
            //}

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
                    SqlCommand cmdProdutos = new SqlCommand("insert into produtos (Quantidade, Descricao, Montante, cliente_ID) values(@Quantidade, @Descricao, @Montante, @ID)", sqlCon);
                    SqlCommand cmdPedido = new SqlCommand("insert into pedido (Total, data_pedido, ID_produtos) values(@Total, @Data, @IDprodutos)", sqlCon);             
                    cmdCliente.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = Nome.Text;
                    cmdCliente.Parameters.Add("@Morada", SqlDbType.VarChar, 50).Value = Morada.Text;
                    cmdCliente.Parameters.Add("@Telefone", SqlDbType.VarChar, 50).Value = Telefone.Text;
                    cmdCliente.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password.Text;
                    cmdPedido.Parameters.Add("@Data", SqlDbType.Date).Value = Data.Text;
                    sqlCon.Open();
                    for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        cmdProdutos.Parameters.Add("@Quantidade", SqlDbType.Int).Value = dataGridView1.Rows[i].Cells["Quantidade"].Value;
                        cmdProdutos.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells["Descricao"].Value;
                        cmdProdutos.Parameters.Add("@Montante", SqlDbType.Money).Value = dataGridView1.Rows[i].Cells["Montante"].Value;
                        cmdPedido.Parameters.Add("@Total", SqlDbType.Money).Value = dataGridView1.Rows[i].Cells["Total"].Value;

                        SqlCommand sqlID = new SqlCommand("select max(IDcliente) from cliente", sqlCon);
                        int IDcliente = Convert.ToInt32(sqlID.ExecuteScalar());
                        cmdProdutos.Parameters.Add("@ID", SqlDbType.Int).Value = IDcliente;
                        

                    }
                    SqlCommand sqlIDproduto = new SqlCommand("select max(IDprodutos) from produtos", sqlCon);
                    int IDprodutos = Convert.ToInt32(sqlIDproduto.ExecuteScalar());
                    cmdPedido.Parameters.Add("@IDprodutos", SqlDbType.Int).Value = IDprodutos;

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
            //Excel.Workbooks myExcelWorkbooks;
            //Excel.Workbook myExcelWorkbook;
            //object misValue = System.Reflection.Missing.Value;
            //Excel.Application xlapp = new Excel.Application();
            //xlapp.Visible = true;
            //myExcelWorkbooks = xlapp.Workbooks;
            //String fileName = "C:\\Users\\2219105\\source\\repos\\luisagosti\\PSI1619I_LuisAgostinho_2219105\\ProjetoFaturas\\ProjetoFaturas\\fatura.xlsx";
            //myExcelWorkbook = myExcelWorkbooks.Open(fileName, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
            //Excel.Worksheet myExcelWorksheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;
            //xlapp.get_Range("B13", misValue).Formula = Nome.Text;
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
    }
}






//SqlCommand sqlCmd_cliente = new SqlCommand("nova fatura", sqlCon);
//sqlCmd_cliente.CommandType = CommandType.StoredProcedure;
//sqlCmd_cliente.Parameters.AddWithValue("@Nome", Nome.Text.Trim());
//sqlCmd_cliente.Parameters.AddWithValue("@Morada", Morada.Text.Trim());
//sqlCmd_cliente.Parameters.AddWithValue("@Telefone", Telefone.Text.Trim());
//sqlCmd_cliente.Parameters.AddWithValue("@Password", Password.Text.Trim());
//sqlCmd.Parameters.AddWithValue("@Data", dateTimePicker1.Text.Trim());
//sqlCmd.Parameters.AddWithValue("@Montante", Guito.Text.Trim());

//string query = "select max(IDcliente) from cliente";
//string query2 = "select SCOPE_IDENTITY()";

//SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
//sqlCmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = Nome.Text;
//sqlCmd.Parameters.Add("@Morada", SqlDbType.VarChar, 50).Value = Morada.Text;
//sqlCmd.Parameters.Add("@Telefone", SqlDbType.VarChar, 50).Value = Telefone.Text;
//sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password.Text;
//for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
//{
//    sqlCmd.Parameters.Add("@Quantidade", SqlDbType.Int).Value = dataGridView1.Rows[i].Cells[0].Value;
//    sqlCmd.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
//    sqlCmd.Parameters.Add("@Montante", SqlDbType.Money).Value = dataGridView1.Rows[i].Cells[2].Value;
//    sqlCmd.Parameters.Add("@Total", SqlDbType.Money).Value = dataGridView1.Rows[i].Cells[3].Value;
//}
//SqlDataAdapter sdr = new SqlDataAdapter(sqlCmd);
//sqlCon.Open();
//sqlCmd.ExecuteNonQuery();
//MessageBox.Show(" Emitida com sucesso.", " Sucesso! ", MessageBoxButtons.OK, MessageBoxIcon.Information);