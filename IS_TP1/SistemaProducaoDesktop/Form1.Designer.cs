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
            btnGerar.Location = new Point(22, 21);
            btnGerar.Margin = new Padding(4, 5, 4, 5);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(179, 50);
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
            dgvProdutos.Location = new Point(22, 100);
            dgvProdutos.Margin = new Padding(4, 5, 4, 5);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.RowHeadersWidth = 62;
            dgvProdutos.Size = new Size(794, 338);
            dgvProdutos.TabIndex = 1;
            // 
            // btnExecutarSikuli
            // 
            btnExecutarSikuli.Location = new Point(621, 21);
            btnExecutarSikuli.Margin = new Padding(4, 5, 4, 5);
            btnExecutarSikuli.Name = "btnExecutarSikuli";
            btnExecutarSikuli.Size = new Size(179, 50);
            btnExecutarSikuli.TabIndex = 2;
            btnExecutarSikuli.Text = "Automatizar";
            btnExecutarSikuli.UseVisualStyleBackColor = true;
            btnExecutarSikuli.Click += btnExecutarSikuli_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 462);
            Controls.Add(dgvProdutos);
            Controls.Add(btnGerar);
            Controls.Add(btnExecutarSikuli);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(860, 507);
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