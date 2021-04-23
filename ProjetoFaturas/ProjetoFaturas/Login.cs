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
        public static string stringConnection = @"Server=tcp:UED1311\SQLEXPRESS;Database=outonoDB;User Id=sa;Password=Pa$$w0rd";
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "user" && maskedTextBox1.Text == "123")
            {
                new Empregado().Show();
                this.Hide();
            }
            else if(textBox1.Text == "admin" && maskedTextBox1.Text == "321")
            {
                new Gerente().Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show(" Utilizador/Password errado.", " Erro! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                maskedTextBox1.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
