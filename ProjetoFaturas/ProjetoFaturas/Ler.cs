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
            string sqlquery = "select * from cliente join produtos on cliente.IDcliente = produtos.cliente_ID";
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
            string sqlquery = "select * from cliente join produtos on cliente.IDcliente = produtos.cliente_ID";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            if (textBox1.Text.Length > 0)
            {
                string query = "select * from cliente join produtos on cliente.IDcliente = produtos.cliente_ID";
                query += " WHERE Nome LIKE '%' + @procura + '%'";
                query += " OR Morada LIKE '%' + @procura + '%'";
                query += " OR Telefone LIKE '%' + @procura + '%'";
                query += " OR Password LIKE '%' + @procura + '%'";
                query += " OR Montante LIKE '%' + @procura + '%'";
                query += " OR Quantidade LIKE '%' + @procura + '%'";
                query += " OR Descricao LIKE '%' + @procura + '%'";
                query += " OR @SearchTerm = ''";
                sqlcomm.Parameters.AddWithValue("@procura", textBox1.Text.Trim());
                using (SqlDataAdapter sda = new SqlDataAdapter(sqlcomm))
                {
                    sda.Fill(dt);
                }
            }
            else
            {
                sdr.Fill(dt);
            }
            //dataGridView1.DataSource = dt;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

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
//"select * from fatura where '" + textBox1.Text + "' in (Nome, Morada, Telefone, Descricao, Equipamento, Password, Montante) order by Nome"