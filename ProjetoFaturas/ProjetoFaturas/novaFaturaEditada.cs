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
            if (Nome.Text == "" || Morada.Text == "" || Telefone.Text == "" || Password.Text == "")
            {
                MessageBox.Show(" Alguns campos obrigatórios não estão preenchidos.", " Erro! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd_cliente = new SqlCommand("fatura", sqlCon);
                    sqlCmd_cliente.CommandType = CommandType.StoredProcedure;
                    sqlCmd_cliente.Parameters.AddWithValue("@Nome", Nome.Text.Trim());
                    sqlCmd_cliente.Parameters.AddWithValue("@Morada", Morada.Text.Trim());
                    sqlCmd_cliente.Parameters.AddWithValue("@Telefone", Telefone.Text.Trim());
                    sqlCmd_cliente.Parameters.AddWithValue("@Password", Password.Text.Trim());
                    SqlCommand SqlCmd_produtos = new SqlCommand("vendas", sqlCon);
                    SqlCmd_produtos.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < dataGridView1.Rows.Count-1; ++i)
                    {
                        SqlCmd_produtos.Parameters.Add("@Quantidade", SqlDbType.Int).Value = dataGridView1.Rows[i].Cells[0].Value;
                        SqlCmd_produtos.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = dataGridView1.Rows[i].Cells[1].Value;
                        SqlCmd_produtos.Parameters.Add("@Montante", SqlDbType.Money).Value = dataGridView1.Rows[i].Cells[2].Value;
                        SqlCmd_produtos.ExecuteNonQuery();
                    }
                    sqlCmd_cliente.ExecuteNonQuery();
                    MessageBox.Show(" Emitida com sucesso.", " Sucesso! ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void Guito_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
            {
                Guito.Text = Convert.ToString(Convert.ToDecimal(dataGridView1.Rows[i].Cells[0].Value)* Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value));
            }
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