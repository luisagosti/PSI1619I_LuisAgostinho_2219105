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
        static public bool IsAdmin = false;
        static public bool login = false;



        SqlConnection con;
        SqlCommand cmd;
        //public static string stringConnection = @"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127";
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button_login_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(@"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127");
                cmd = new SqlCommand("select UserId, Password, IsAdmin from login where UserId=@UserId and Password=@Password", con);
                cmd.Parameters.Add("@UserId", SqlDbType.VarChar, 50).Value = textBox1.Text;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = maskedTextBox1.Text;
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    login = true;
                    int ver = 0;
                    reader.Read();
                    ver = Convert.ToInt32(reader["IsAdmin"]);
                    if (ver == 1)
                    {
                        IsAdmin = true;
                    }
                    con.Close();
                    this.Close();                
                }
                else
                {
                    MessageBox.Show(" Utilizador/Password errado.", " Erro! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    maskedTextBox1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha de conexão à BD: \n{ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Clear();
                textBox1.Clear();
            }
            finally
            {
                con.Close();
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

/*
Sitações necessárias fazer ainda:
    - Design melhor
    - Importar para PDF para o amigo decidir se quer imprimir
    - Situação de procurar onde basta colocar uma letra e ele procura tudo com isso - SQL
    - Tratar da novaFaturaEditada - SQL
    - Tratar do Ler - SQL
*/