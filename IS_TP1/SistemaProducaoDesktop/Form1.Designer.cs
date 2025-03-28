namespace SistemaProducaoDesktop
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnGerar = new Button();
            btnExecutarSikuli = new Button();
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

            // btnGerar
            btnGerar.Location = new Point(18, 17);
            btnGerar.Margin = new Padding(3, 4, 3, 4);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(143, 40);
            btnGerar.TabIndex = 0;
            btnGerar.Text = "Gerar Produto";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;

            // btnExecutarSikuli
            btnExecutarSikuli.Location = new Point(497, 17);
            btnExecutarSikuli.Margin = new Padding(3, 4, 3, 4);
            btnExecutarSikuli.Name = "btnExecutarSikuli";
            btnExecutarSikuli.Size = new Size(143, 40);
            btnExecutarSikuli.TabIndex = 2;
            btnExecutarSikuli.Text = "Automatizar";
            btnExecutarSikuli.UseVisualStyleBackColor = true;
            btnExecutarSikuli.Click += btnExecutarSikuli_Click;

            // button1
            button1.Location = new Point(178, 17);
            button1.Name = "button1";
            button1.Size = new Size(141, 40);
            button1.TabIndex = 3;
            button1.Text = "Parar Produção";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnParar_Click;

            // lblCodigo
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(18, 80);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(100, 20);
            lblCodigo.TabIndex = 4;
            lblCodigo.Text = "Código Peça:";

            // txtCodigo
            txtCodigo.Location = new Point(18, 103);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(200, 27);
            txtCodigo.TabIndex = 5;

            // lblData
            lblData.AutoSize = true;
            lblData.Location = new Point(18, 143);
            lblData.Name = "lblData";
            lblData.Size = new Size(47, 20);
            lblData.TabIndex = 6;
            lblData.Text = "Data:";

            // txtData
            txtData.Location = new Point(18, 166);
            txtData.Name = "txtData";
            txtData.ReadOnly = true;
            txtData.Size = new Size(200, 27);
            txtData.TabIndex = 7;

            // lblHora
            lblHora.AutoSize = true;
            lblHora.Location = new Point(18, 206);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(46, 20);
            lblHora.TabIndex = 8;
            lblHora.Text = "Hora:";

            // txtHora
            txtHora.Location = new Point(18, 229);
            txtHora.Name = "txtHora";
            txtHora.ReadOnly = true;
            txtHora.Size = new Size(200, 27);
            txtHora.TabIndex = 9;

            // lblTempo
            lblTempo.AutoSize = true;
            lblTempo.Location = new Point(18, 269);
            lblTempo.Name = "lblTempo";
            lblTempo.Size = new Size(144, 20);
            lblTempo.TabIndex = 10;
            lblTempo.Text = "Tempo Produção (s):";

            // txtTempo
            txtTempo.Location = new Point(18, 292);
            txtTempo.Name = "txtTempo";
            txtTempo.ReadOnly = true;
            txtTempo.Size = new Size(200, 27);
            txtTempo.TabIndex = 11;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 370);
            Controls.Add(txtTempo);
            Controls.Add(lblTempo);
            Controls.Add(txtHora);
            Controls.Add(lblHora);
            Controls.Add(txtData);
            Controls.Add(lblData);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Controls.Add(button1);
            Controls.Add(btnExecutarSikuli);
            Controls.Add(btnGerar);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(692, 415);
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