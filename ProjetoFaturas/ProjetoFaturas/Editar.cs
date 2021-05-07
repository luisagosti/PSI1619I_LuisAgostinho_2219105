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
    public partial class Editar : Form
    {
        string con = @"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127";
        public Editar()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(con);
            string sqlquery = "select * from fatura order by Nome";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            if (textBox1.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from fatura where '" + textBox1.Text + "' in (Nome, Morada, Telefone, Descricao, Equipamento, Password, Montante) order by Nome", con);
                sda.Fill(dt);
            }
            else
            {
                sdr.Fill(dt);
            }
            dataGridView1.DataSource = dt;
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(con);
            string sqlquery = "select * from fatura order by Nome";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            sqlconn.Open();
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(con))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("editar", sqlCon);
                DataGridViewRow dgvRow = dataGridView1.CurrentRow;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Nome",dgvRow.Cells["Nome"].Value==DBNull.Value ? "":dgvRow.Cells["Nome"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@Morada", dgvRow.Cells["Morada"].Value == DBNull.Value ? "" : dgvRow.Cells["Morada"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@Telefone", Convert.ToInt32(dgvRow.Cells["Telefone"].Value == DBNull.Value ? "" : dgvRow.Cells["Telefone"].Value.ToString()));
                sqlCmd.Parameters.AddWithValue("@Descricao", dgvRow.Cells["Descricao"].Value == DBNull.Value ? "" : dgvRow.Cells["Descricao"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@Equipamento", dgvRow.Cells["Equipamento"].Value == DBNull.Value ? "" : dgvRow.Cells["Equipamento"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@Password", dgvRow.Cells["Password"].Value == DBNull.Value ? "" : dgvRow.Cells["Password"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@Data", Convert.ToDateTime(dgvRow.Cells["Data"].Value == DBNull.Value ? "" : dgvRow.Cells["Data"].Value.ToString()));
                sqlCmd.Parameters.AddWithValue("@Montante", dgvRow.Cells["Montante"].Value == DBNull.Value ? "" : dgvRow.Cells["Montante"].Value.ToString());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show(" Editada com sucesso.", " Sucesso! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if(dataGridView1.CurrentRow.Cells["Nome"].Value != DBNull.Value)
            {
                if (MessageBox.Show("Tem a certeza que pretende apagar?", "dataGridView", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection sqlCon = new SqlConnection(con))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("apagar", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@Nome", dataGridView1.CurrentRow.Cells["Nome"].Value);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
