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
    
    public partial class Login : Form
    {
        public string UserID = "";
        public string IsAdmin = "";
        

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        //public static string stringConnection = @"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127";
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            String result = "";
            try
            {
                con = new SqlConnection(@"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127");
                cmd = new SqlCommand("select * from login where UserId=@uid and Password=@password", con);
                con.Open();
                cmd.Parameters.AddWithValue("@uid", textBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@password", maskedTextBox1.Text.ToString());
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Password"].ToString().Equals(maskedTextBox1.Text.ToString(), StringComparison.InvariantCulture))
                    {
                        UserID = reader["UserId"].ToString();
                        result = "1";
                        using (SqlCommand SelectCommand = new SqlCommand(cmd.ToString(), con))
                        {
                            con.Open();
                            SelectCommand.Parameters.Add("@IsAdmin", SqlDbType.Char).Value = textBox1.Text;
                            int i = (int)SelectCommand.ExecuteScalar();
                            if (i > 0)
                            {
                                IsAdmin = "1";
                            }
                        }
                    }
                    else
                        result = "Invalid credentials";
                }
                else
                    MessageBox.Show(" Utilizador/Password errado.", " Erro! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    maskedTextBox1.Clear();
                    reader.Close();
                    cmd.Dispose();
                    con.Close();

            }
            catch (Exception ex)
            {
                
            }

            if (result == "1")
            {
                this.Hide();
                var Gerente = new Painel();
                Gerente.Closed += (s, args) => this.Close();
                Gerente.Show();

            }
            
        }
    

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}