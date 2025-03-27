using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SistemaProducaoDesktop
{
    public partial class Form1 : Form
    {
        private List<Produto> produtos = new List<Produto>();
        

        public Form1()
        {
            InitializeComponent();
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

                // Atualiza o DataGridView
                dgvProdutos.DataSource = null;
                dgvProdutos.DataSource = produtos;

                // Espera tempo aleatório
                await Task.Delay(novo.Tempo_Producao*1000);
            }

            btnGerar.Enabled = true;
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            gerando = false;
            btnGerar.Enabled = true;
        }



        private async void btnExecutarSikuli_Click(object sender, EventArgs e)
        {
            string caminhoSikuliX = @"C:\Users\pauli\Desktop\sikulixide-2.0.5.jar";
            string caminhoScript = @"C:\Users\pauli\Desktop\IS\TP1\IS_TP1-Sikulix\TP1_sikulix.py";
            string caminhoDados = @"C:\Users\pauli\Desktop\IS\TP1\dados.txt";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "java",
                Arguments = $"-jar \"{caminhoSikuliX}\" -r \"{caminhoScript}\" \"{caminhoDados}\"", // Aspas escapadas
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process processo = Process.Start(psi))
            {
                string saida = await processo.StandardOutput.ReadToEndAsync();
                await Task.Run(() => processo.WaitForExit());
                //MessageBox.Show(saida, "Resultado do SikuliX");

                File.WriteAllText(caminhoDados, string.Empty);
            }
        }

    }
}
