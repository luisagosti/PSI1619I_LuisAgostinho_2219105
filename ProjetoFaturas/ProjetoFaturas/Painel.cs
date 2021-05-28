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
        public Painel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool aberto = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "novaFaturaEditada")
                {
                    aberto = true;
                    f.BringToFront();
                    break;
                }
            }
            if (aberto == false)
            {
                novaFaturaEditada nova = new novaFaturaEditada();
                foreach (Form c in this.MdiChildren)
                {
                    c.Close();
                }
                nova.MdiParent = this;
                nova.Show();
                nova.Location = new Point(0, 0);
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
                foreach (Form c in this.MdiChildren)
                {
                    c.Close();
                }
                nova.MdiParent = this;
                nova.Show();
                nova.Location = new Point(0, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
                foreach (Form c in this.MdiChildren)
                {
                    c.Close();
                }
                nova.MdiParent = this;
                nova.Show();
                nova.Location = new Point(0, 0);
            }
        }

        private void Painel_Load(object sender, EventArgs e)
        {

            if (Login.IsAdmin == false)
            {
                editarFatura.Enabled = false;
            }
            else
            {
                editarFatura.Enabled = true;
            }
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.White;
                }
            }
        }
    }
}
