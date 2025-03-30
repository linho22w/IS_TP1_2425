using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SistemaProducaoDesktop
{
    public partial class Form1 : Form
    {
        private List<Produto> produtos = new List<Produto>();


        public Form1()
        {
            InitializeComponent();
            // Mover a janela ao inicializar
            this.StartPosition = FormStartPosition.Manual; 
            this.Location = new Point(0, 200); 

        }

        private Random random = new Random();
        private bool gerando = false;

        private async void btnGerar_Click(object sender, EventArgs e)
        {
            btnGerar.Enabled = false;
            gerando = true;

            while (gerando)
            {
                // Cria e adiciona o produto
                Produto novo = Produto.GerarProdutoAleatorio();
                produtos.Insert(0, novo);

                // Atualiza as TextBoxes
                txtCodigo.Text = novo.Codigo_Peca;
                txtData.Text = novo.Data_Producao.ToShortDateString();
                txtHora.Text = novo.Hora_Producao.ToString(@"hh\:mm\:ss");
                txtTempo.Text = novo.Tempo_Producao.ToString();

                await Task.Delay(15 * 1000); //15 segundos entre cada produto gerado
            }

            btnGerar.Enabled = true;
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            gerando = false;
            btnGerar.Enabled = true;
        }

    }
}
