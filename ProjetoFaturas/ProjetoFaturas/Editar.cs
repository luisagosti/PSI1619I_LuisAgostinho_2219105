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
        SqlDataAdapter sda;
        SqlCommandBuilder scd;
        DataTable dt;
        public Editar()
        {
            InitializeComponent();
        }
        //Editar o texto dentro das caixas da dataGrid
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(con);
            string sqlquery = "select * from cliente join produtos on cliente.IDcliente = produtos.cliente_ID";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            if (textBox1.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from cliente join produtos on cliente.IDcliente = produtos.cliente_ID", con);
                sda.Fill(dt);
            }
            else
            {
                sdr.Fill(dt);
            }
            dataGridView1.DataSource = dt;
        }
        //Dar Load dos dados da gridView
        private void Editar_Load(object sender, EventArgs e)
        {
            LoadAspasAspas();

        } 

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAspasAspas();
        }

        private void LoadAspasAspas()
        {

            SqlConnection sqlconn = new SqlConnection(con);
            string sqlquery = "select * from cliente join produtos on cliente.IDcliente = produtos.cliente_ID";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            sqlconn.Open();
            dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select * from cliente join produtos on cliente.IDcliente = produtos.cliente_ID", con);
            scd = new SqlCommandBuilder(sda);

            sda.Update(dt);
        }
    }
}