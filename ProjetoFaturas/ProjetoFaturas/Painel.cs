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
    public partial class Painel : Form
    {
        string con = @"Server=tcp:devlabpm.westeurope.cloudapp.azure.com;Database=PSIM1619I_LuisAgostinho_2219105;User Id=PSIM1619I_LuisAgostinho_2219105;Password=6qA8C127";
        public Painel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool aberto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "novaFatura")
                {
                    aberto = true;
                    f.BringToFront();
                    break;
                }
            }
            if (aberto == false)
            {
                novaFatura nova = new novaFatura();
                Editar novaEditar = new Editar();
                Ler novaLer = new Ler();
                nova.MdiParent = this;
                novaEditar.Close();
                novaLer.Close();
                nova.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool aberto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Ler")
                {
                    aberto = true;
                    f.BringToFront();
                    break;
                }
            }
            if (aberto == false)
            {
                Ler nova = new Ler();
                novaFatura novaNova = new novaFatura();
                Editar novaEditar = new Editar();
                nova.MdiParent = this;
                novaNova.Close();
                novaEditar.Close();
                nova.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(con);
            bool aberto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Editar")
                {
                    aberto = true;
                    f.BringToFront();
                    break;
                }
            }
            if (aberto == false)
            {
                Editar nova = new Editar();
                novaFatura novaNova = new novaFatura();
                Ler novaLer = new Ler();
                nova.MdiParent = this;
                nova.Show();
            }
        }

        private void Painel_Load(object sender, EventArgs e)
        {
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.White;
                }
            }
        }
    }
}
