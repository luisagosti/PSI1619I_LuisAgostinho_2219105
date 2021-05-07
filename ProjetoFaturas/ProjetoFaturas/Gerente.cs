using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFaturas
{
    public partial class Gerente : Form
    {
        public Gerente()
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
    }
}
