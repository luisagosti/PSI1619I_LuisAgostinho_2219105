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
            if (Nome.Text == "" || Morada.Text == "" || Telefone.Text == "" || Password.Text == "" || Guito.Text == "")
            {
                MessageBox.Show(" Alguns campos não estão completos ou são inválidos.", " Erro! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("novaFatura", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Nome", Nome.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Morada", Morada.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Telefone", Telefone.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", Password.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Data", dateTimePicker1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Montante", Guito.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(" Emitida com sucesso.", " Sucesso! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
