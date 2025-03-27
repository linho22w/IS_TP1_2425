namespace sistema_legado
{
    partial class Form1
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
        /// Required method for Designer support. 
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridProdutos = new DataGridView();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnSalvar = new Button();
            txtTempo = new TextBox();
            dtHora = new DateTimePicker();
            dtData = new DateTimePicker();
            txtCodigo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)gridProdutos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // gridProdutos
            // 
            gridProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridProdutos.ColumnHeadersHeight = 34;
            gridProdutos.Dock = DockStyle.Bottom;
            gridProdutos.Location = new Point(0, 219);
            gridProdutos.Name = "gridProdutos";
            gridProdutos.RowHeadersWidth = 51;
            gridProdutos.Size = new Size(937, 413);
            gridProdutos.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnSalvar);
            groupBox1.Controls.Add(txtTempo);
            groupBox1.Controls.Add(dtHora);
            groupBox1.Controls.Add(dtData);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(937, 213);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registar novo Produto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 165);
            label4.Name = "label4";
            label4.Size = new Size(125, 20);
            label4.TabIndex = 8;
            label4.Text = "Tempo (minutos):";
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
            btnSalvar.Location = new Point(400, 160);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(100, 30);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Guardar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnGuardar_Click;
            // 
            // txtTempo
            // 
            txtTempo.Location = new Point(150, 160);
            txtTempo.Name = "txtTempo";
            txtTempo.Size = new Size(200, 27);
            txtTempo.TabIndex = 3;
            // 
            // dtHora
            // 
            dtHora.Format = DateTimePickerFormat.Time;
            dtHora.Location = new Point(150, 120);
            dtHora.Name = "dtHora";
            dtHora.ShowUpDown = true;
            dtHora.Size = new Size(200, 27);
            dtHora.TabIndex = 2;
            // 
            // dtData
            // 
            dtData.Format = DateTimePickerFormat.Short;
            dtData.Location = new Point(150, 80);
            dtData.Name = "dtData";
            dtData.Size = new Size(200, 27);
            dtData.TabIndex = 1;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(150, 40);
            txtCodigo.Multiline = true;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 27);
            txtCodigo.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(937, 632);
            Controls.Add(groupBox1);
            Controls.Add(gridProdutos);
            Name = "Form1";
            Text = "Sistema Legado de Produção";
            ((System.ComponentModel.ISupportInitialize)gridProdutos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridProdutos;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSalvar;
        private TextBox txtTempo;
        private DateTimePicker dtHora;
        private DateTimePicker dtData;
        private TextBox txtCodigo;
    }
}
