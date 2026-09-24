using System.Xml.Linq;

namespace SistemaProducaoDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGerar = new Button();
            button1 = new Button();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblData = new Label();
            txtData = new TextBox();
            lblHora = new Label();
            txtHora = new TextBox();
            lblTempo = new Label();
            txtTempo = new TextBox();
            SuspendLayout();
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(22, 21);
            btnGerar.Margin = new Padding(4, 5, 4, 5);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(179, 50);
            btnGerar.TabIndex = 0;
            btnGerar.Text = "Gerar Produto";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(222, 21);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(176, 50);
            button1.TabIndex = 3;
            button1.Text = "Parar Produção";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnParar_Click;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(22, 100);
            lblCodigo.Margin = new Padding(4, 0, 4, 0);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(115, 25);
            lblCodigo.TabIndex = 4;
            lblCodigo.Text = "Código Peça:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(22, 129);
            txtCodigo.Margin = new Padding(4, 4, 4, 4);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(249, 31);
            txtCodigo.TabIndex = 5;
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new Point(22, 179);
            lblData.Margin = new Padding(4, 0, 4, 0);
            lblData.Name = "lblData";
            lblData.Size = new Size(53, 25);
            lblData.TabIndex = 6;
            lblData.Text = "Data:";
            // 
            // txtData
            // 
            txtData.Location = new Point(22, 208);
            txtData.Margin = new Padding(4, 4, 4, 4);
            txtData.Name = "txtData";
            txtData.ReadOnly = true;
            txtData.Size = new Size(249, 31);
            txtData.TabIndex = 7;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(22, 258);
            lblHora.Margin = new Padding(4, 0, 4, 0);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(55, 25);
            lblHora.TabIndex = 8;
            lblHora.Text = "Hora:";
            // 
            // txtHora
            // 
            txtHora.Location = new Point(22, 286);
            txtHora.Margin = new Padding(4, 4, 4, 4);
            txtHora.Name = "txtHora";
            txtHora.ReadOnly = true;
            txtHora.Size = new Size(249, 31);
            txtHora.TabIndex = 9;
            // 
            // lblTempo
            // 
            lblTempo.AutoSize = true;
            lblTempo.Location = new Point(22, 336);
            lblTempo.Margin = new Padding(4, 0, 4, 0);
            lblTempo.Name = "lblTempo";
            lblTempo.Size = new Size(174, 25);
            lblTempo.TabIndex = 10;
            lblTempo.Text = "Tempo Produção (s):";
            // 
            // txtTempo
            // 
            txtTempo.Location = new Point(22, 365);
            txtTempo.Margin = new Padding(4, 4, 4, 4);
            txtTempo.Name = "txtTempo";
            txtTempo.ReadOnly = true;
            txtTempo.Size = new Size(249, 31);
            txtTempo.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 462);
            Controls.Add(txtTempo);
            Controls.Add(lblTempo);
            Controls.Add(txtHora);
            Controls.Add(lblHora);
            Controls.Add(txtData);
            Controls.Add(lblData);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Controls.Add(button1);
            Controls.Add(btnGerar);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(860, 505);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Produção";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGerar;
        private Button btnExecutarSikuli;
        private Button button1;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblData;
        private TextBox txtData;
        private Label lblHora;
        private TextBox txtHora;
        private Label lblTempo;
        private TextBox txtTempo;
    }
}