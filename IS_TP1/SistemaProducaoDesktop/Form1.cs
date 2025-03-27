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
        private string caminhoFicheiro = "C:\\Users\\pauli\\Desktop\\IS\\TP1\\dados.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            Produto novoProduto = Produto.GerarProdutoAleatorio();
            produtos.Insert(0,novoProduto);

            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = produtos;

            //GuardarProdutoEmCSV(novoProduto);
        }

        //private void GuardarProdutoEmCSV(Produto produto)
        //{
        //    using (StreamWriter sw = new StreamWriter(caminhoFicheiro, true))
        //    {
        //        sw.WriteLine($"{produto.Codigo_Peca},{produto.Data_Producao:dd-MM-yyyy},{produto.Hora_Producao:hh\\:mm\\:ss},{produto.Tempo_Producao},{produto.Codigo_Resultado}");
        //    }
        //}

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
