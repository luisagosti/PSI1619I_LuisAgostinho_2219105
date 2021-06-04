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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Nome.Text == "" || Morada.Text == "" || Telefone.Text == "")
            {
                MessageBox.Show(" Alguns campos obrigatórios não estão preenchidos.", " Erro! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sqlQuery = "insert into cliente (Nome, Morada, Telefone, Password) values (@Nome, @Morada, @Telefone, @Password) insert into produtos (Quantidade, Descricao, Montante) values(@Quantidade, @Descricao, @Montante) insert into pedido (Total) values(@Total)";
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
                    sqlCmd.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = Nome.Text;
                    sqlCmd.Parameters.Add("@Morada", SqlDbType.VarChar, 50).Value = Morada.Text;
                    sqlCmd.Parameters.Add("@Telefone", SqlDbType.VarChar, 50).Value = Telefone.Text;
                    sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password.Text;
                    for (int i = 0; i < dataGridView1.Rows.Count-1; ++i)
                    {
                        sqlCmd.Parameters.Add("@Quantidade", SqlDbType.Int).Value = dataGridView1.Rows[i].Cells[0].Value;
                        sqlCmd.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
                        sqlCmd.Parameters.Add("@Montante", SqlDbType.Money).Value = dataGridView1.Rows[i].Cells[2].Value;
                        sqlCmd.Parameters.Add("@Total", SqlDbType.Money).Value = dataGridView1.Rows[i].Cells[3].Value;
                    }
                    SqlDataAdapter sdr = new SqlDataAdapter(sqlCmd);
                    sqlCon.Open();
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(" Emitida com sucesso.", " Sucesso! ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[dataGridView1.Columns["totalsIVA"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["Quantidade"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Montante"].Index].Value));
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[dataGridView1.Columns["Total"].Index].Value = ((Convert.ToDouble(row.Cells[dataGridView1.Columns["TotalsIva"].Index].Value) * 0.23) + Convert.ToDouble(row.Cells[dataGridView1.Columns["TotalsIva"].Index].Value));
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


//SqlCommand SqlCmd_cliente = new SqlCommand("insert into cliente values('" + Nome.Text + "', '" + Morada.Text + "', '" + Telefone.Text + "', '" + Password.Text + "')", sqlCon);
//dataGridView1.RowCount = 3;
//SqlCommand SqlCmd_produtos = new SqlCommand("insert into produtos values('"+dataGridView1.Rows[0].Cells["Quantidade"].Value+ "', '" + dataGridView1.Rows[1].Cells["Descricao"].Value + "', '" + dataGridView1.Rows[2].Cells["Montante"].Value + "')", sqlCon);
//SqlCmd_cliente.ExecuteNonQuery();
//SqlCmd_produtos.ExecuteNonQuery();
//double guito = Convert.ToDouble(dataGridView1.Rows[0].Cells["Quantidade"].Value) * Convert.ToDouble(dataGridView1.Rows[2].Cells["Montante"].Value);
//Guito.Text = Convert.ToString(guito);
//MessageBox.Show(" Emitida com sucesso.", " Sucesso! ", MessageBoxButtons.OK, MessageBoxIcon.Information);


//DataGridViewRow dgvRow = dataGridView1.CurrentRow;
//SqlCmd_produtos.Parameters.AddWithValue("@Quantidade", dgvRow.Cells["Quantidade"].Value == DBNull.Value ? "" : dgvRow.Cells["Quantidade"].Value.ToString());
//SqlCmd_produtos.Parameters.AddWithValue("@Descricao", dgvRow.Cells["Descricao"].Value == DBNull.Value ? "" : dgvRow.Cells["Descricao"].Value.ToString());
//SqlCmd_produtos.Parameters.AddWithValue("@Montante", dgvRow.Cells["Montante"].Value == DBNull.Value ? "" : dgvRow.Cells["Montante"].Value.ToString());