
namespace ProjetoFaturas
{
    partial class Painel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.editarFatura = new System.Windows.Forms.Button();
            this.lerFatura = new System.Windows.Forms.Button();
            this.novaFatura = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.editarFatura);
            this.panel1.Controls.Add(this.lerFatura);
            this.panel1.Controls.Add(this.novaFatura);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 688);
            this.panel1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(-1, 641);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 42);
            this.button4.TabIndex = 3;
            this.button4.Text = "Sair";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // editarFatura
            // 
            this.editarFatura.FlatAppearance.BorderSize = 0;
            this.editarFatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editarFatura.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editarFatura.ForeColor = System.Drawing.Color.White;
            this.editarFatura.Location = new System.Drawing.Point(-1, 259);
            this.editarFatura.Name = "editarFatura";
            this.editarFatura.Size = new System.Drawing.Size(136, 47);
            this.editarFatura.TabIndex = 2;
            this.editarFatura.Text = "Editar Fatura";
            this.editarFatura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editarFatura.UseVisualStyleBackColor = true;
            this.editarFatura.Click += new System.EventHandler(this.button3_Click);
            // 
            // lerFatura
            // 
            this.lerFatura.FlatAppearance.BorderSize = 0;
            this.lerFatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lerFatura.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lerFatura.ForeColor = System.Drawing.Color.White;
            this.lerFatura.Location = new System.Drawing.Point(-1, 206);
            this.lerFatura.Name = "lerFatura";
            this.lerFatura.Size = new System.Drawing.Size(136, 47);
            this.lerFatura.TabIndex = 1;
            this.lerFatura.Text = "Ler Fatura";
            this.lerFatura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lerFatura.UseVisualStyleBackColor = true;
            this.lerFatura.Click += new System.EventHandler(this.button2_Click);
            // 
            // novaFatura
            // 
            this.novaFatura.FlatAppearance.BorderSize = 0;
            this.novaFatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.novaFatura.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novaFatura.ForeColor = System.Drawing.Color.White;
            this.novaFatura.Location = new System.Drawing.Point(-1, 153);
            this.novaFatura.Name = "novaFatura";
            this.novaFatura.Size = new System.Drawing.Size(136, 47);
            this.novaFatura.TabIndex = 0;
            this.novaFatura.Text = "Nova Fatura";
            this.novaFatura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.novaFatura.UseVisualStyleBackColor = true;
            this.novaFatura.Click += new System.EventHandler(this.button1_Click);
            // 
            // Painel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 688);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Painel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outono - Faturação";
            this.Load += new System.EventHandler(this.Painel_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button novaFatura;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button editarFatura;
        private System.Windows.Forms.Button lerFatura;
    }
}