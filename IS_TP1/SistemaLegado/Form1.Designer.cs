namespace sistema_legado
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
            groupBox1 = new GroupBox();
            txtHora = new TextBox();
            txtData = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnSalvar = new Button();
            txtTempo = new TextBox();
            txtCodigo = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtHora);
            groupBox1.Controls.Add(txtData);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnSalvar);
            groupBox1.Controls.Add(txtTempo);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 213);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registar novo Produto";
            // 
            // txtHora
            // 
            txtHora.Location = new Point(150, 120);
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(120, 27);
            txtHora.TabIndex = 2;
            // 
            // txtData
            // 
            txtData.Location = new Point(150, 80);
            txtData.Name = "txtData";
            txtData.Size = new Size(120, 27);
            txtData.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 165);
            label4.Name = "label4";
            label4.Size = new Size(135, 20);
            label4.TabIndex = 8;
            label4.Text = "Tempo (segundos):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 125);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 7;
            label3.Text = "Hora de Prod.:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 85);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 6;
            label2.Text = "Data de Prod.:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 43);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 5;
            label1.Text = "Código da Peça:";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(300, 160);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 30);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Guardar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtTempo
            // 
            txtTempo.Location = new Point(150, 160);
            txtTempo.Name = "txtTempo";
            txtTempo.Size = new Size(120, 27);
            txtTempo.TabIndex = 3;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(150, 40);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 27);
            txtCodigo.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 250);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Produção";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSalvar;
        private TextBox txtTempo;
        private TextBox txtCodigo;
        private TextBox txtHora;
        private TextBox txtData;
    }
}