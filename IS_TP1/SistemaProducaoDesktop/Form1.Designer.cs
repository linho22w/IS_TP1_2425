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
            dgvProdutos = new DataGridView();
            btnExecutarSikuli = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(18, 17);
            btnGerar.Margin = new Padding(3, 4, 3, 4);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(143, 40);
            btnGerar.TabIndex = 0;
            btnGerar.Text = "Gerar Produto";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // dgvProdutos
            // 
            dgvProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new Point(18, 80);
            dgvProdutos.Margin = new Padding(3, 4, 3, 4);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.RowHeadersWidth = 62;
            dgvProdutos.Size = new Size(635, 270);
            dgvProdutos.TabIndex = 1;
            // 
            // btnExecutarSikuli
            // 
            btnExecutarSikuli.Location = new Point(497, 17);
            btnExecutarSikuli.Margin = new Padding(3, 4, 3, 4);
            btnExecutarSikuli.Name = "btnExecutarSikuli";
            btnExecutarSikuli.Size = new Size(143, 40);
            btnExecutarSikuli.TabIndex = 2;
            btnExecutarSikuli.Text = "automatizar";
            btnExecutarSikuli.UseVisualStyleBackColor = true;
            btnExecutarSikuli.Click += btnExecutarSikuli_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 370);
            Controls.Add(dgvProdutos);
            Controls.Add(btnGerar);
            Controls.Add(btnExecutarSikuli);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(692, 417);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Produção";
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnGerar;
        private DataGridView dgvProdutos;
        private Button btnExecutarSikuli;
    }
}