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
    
    public partial class novaFatura : Form
    {
        int i;
        string connectionString = @"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127";
        public novaFatura()
        {
            InitializeComponent();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(Nome.Text) || int.TryParse(Nome.Text, out i))
            {
                errorProvider1.SetError(Nome, "Este campo não pode ficar vazio");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Nome.Text == "" || Morada.Text == "" || Telefone.Text == "" || Descricao.Text == "" || Password.Text == "" || Guito.Text == "")
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
                    sqlCmd.Parameters.AddWithValue("@Descricao", Descricao.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Equipamento", Equipamento.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", Password.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Data", dateTimePicker1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Montante", Guito.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show(" Emitida com sucesso.", " Sucesso! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                //imprimir
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && (e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1) && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Morada.Text) || int.TryParse(Morada.Text, out i))
            {
                errorProvider1.SetError(Morada, "Este campo não pode ficar vazio ou conter numeros");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Telefone.Text))
            {
                errorProvider1.SetError(Telefone, "Este campo não pode ficar vazio");
            }

        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Descricao.Text))
            {
                errorProvider1.SetError(Descricao, "Este campo não pode ficar vazio");
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Text))
            {
                errorProvider1.SetError(Password, "Este campo não pode ficar vazio");
            }
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                errorProvider1.SetError(dateTimePicker1, "Este campo não pode ficar vazio");
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(Guito.Text))
            {
                errorProvider1.SetError(Guito, "Este campo não pode ficar vazio");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                       (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void novaFatura_Load(object sender, EventArgs e)
        {

        }

        private void Guito_TextChanged(object sender, EventArgs e)
        {

        }

        private void Telefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
