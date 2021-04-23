
namespace ProjetoFaturas
{
    partial class Empregado
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.faturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaFauraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lerFaturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.faturaToolStripMenuItem,
            this.ajudaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // faturaToolStripMenuItem
            // 
            this.faturaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaFauraToolStripMenuItem,
            this.lerFaturaToolStripMenuItem});
            this.faturaToolStripMenuItem.Name = "faturaToolStripMenuItem";
            this.faturaToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.faturaToolStripMenuItem.Text = "Fatura";
            // 
            // novaFauraToolStripMenuItem
            // 
            this.novaFauraToolStripMenuItem.Name = "novaFauraToolStripMenuItem";
            this.novaFauraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.novaFauraToolStripMenuItem.Text = "Nova Fatura";
            this.novaFauraToolStripMenuItem.Click += new System.EventHandler(this.novaFauraToolStripMenuItem_Click);
            // 
            // lerFaturaToolStripMenuItem
            // 
            this.lerFaturaToolStripMenuItem.Name = "lerFaturaToolStripMenuItem";
            this.lerFaturaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lerFaturaToolStripMenuItem.Text = "Ler Fatura";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // Empregado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Empregado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outono - Faturação";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem faturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaFauraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lerFaturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}