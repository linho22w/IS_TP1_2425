using System.Xml.Linq;

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
            groupBox1 = new GroupBox();
            txtHora = new TextBox();
            txtData = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnGuardar = new Button();
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
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(txtTempo);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Location = new Point(25, 25);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(625, 266);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Registar novo Produto";
            // 
            // txtHora
            // 
            txtHora.Location = new Point(188, 150);
            txtHora.Margin = new Padding(4);
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(149, 31);
            txtHora.TabIndex = 2;
            // 
            // txtData
            // 
            txtData.Location = new Point(188, 100);
            txtData.Margin = new Padding(4);
            txtData.Name = "txtData";
            txtData.Size = new Size(149, 31);
            txtData.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 206);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(163, 25);
            label4.TabIndex = 8;
            label4.Text = "Tempo (segundos):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 156);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(127, 25);
            label3.TabIndex = 7;
            label3.Text = "Hora de Prod.:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 106);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 25);
            label2.TabIndex = 6;
            label2.Text = "Data de Prod.:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 54);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 25);
            label1.TabIndex = 5;
            label1.Text = "Código da Peça:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(375, 200);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 38);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtTempo
            // 
            txtTempo.Location = new Point(188, 200);
            txtTempo.Margin = new Padding(4);
            txtTempo.Name = "txtTempo";
            txtTempo.Size = new Size(149, 31);
            txtTempo.TabIndex = 3;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(188, 50);
            txtCodigo.Margin = new Padding(4);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(249, 31);
            txtCodigo.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 312);
            Controls.Add(groupBox1);
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Legado";
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
        private Button btnGuardar;
        private TextBox txtTempo;
        private TextBox txtCodigo;
        private TextBox txtHora;
        private TextBox txtData;


    }
}
