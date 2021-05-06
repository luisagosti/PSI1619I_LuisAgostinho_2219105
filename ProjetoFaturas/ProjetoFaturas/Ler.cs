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
    public partial class Ler : Form
    {
        public Ler()
        {
            InitializeComponent();
        }
        string con = @"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127";
        private void Ler_Load(object sender, EventArgs e)
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}



/*con = new SqlConnection(@"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127");
            cmd = new SqlCommand("select * from fatura where '" +comboBox1.Text.ToString()+ "' = '"+textBox1.Text+"'", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand sqlcomm = new SqlCommand(cmd, con);
            SqlDataAdapter sdr = new SqlDataAdapter();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;*/

/*SqlConnection sqlconn = new SqlConnection(con);
                string sqlquery = "select * from fatura where 1=0";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlconn.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                dataGridView1.DataSource = dt;*/

/*comboBox1.DataSource = dt.Columns.Cast<DataColumn>().ToList();
comboBox1.ValueMember = "ColumnName";
comboBox1.DisplayMember = "ColumnName";*/

//SqlDataAdapter sda = new SqlDataAdapter("select * from fatura where CONCAT('Nome', 'Morada', 'Telefone', 'Equipamento', 'Password', 'Data', 'Montante') like '" + textBox1.Text+"%'", con);