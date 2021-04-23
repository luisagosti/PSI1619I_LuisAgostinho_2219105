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
                nova.MdiParent = this;
                nova.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
