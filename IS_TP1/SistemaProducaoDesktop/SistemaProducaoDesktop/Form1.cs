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
        private string caminhoFicheiro = "C:\\Users\\pauli\\Desktop\\IS\\dados.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            Produto novoProduto = Produto.GerarProdutoAleatorio();
            produtos.Add(novoProduto);

            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = produtos;

            SalvarProdutoEmCSV(novoProduto);
        }

        private void SalvarProdutoEmCSV(Produto produto)
        {
            using (StreamWriter sw = new StreamWriter(caminhoFicheiro, true))
            {
                sw.WriteLine($"{produto.Codigo_Peca},{produto.Data_Producao:yyyy-MM-dd},{produto.Hora_Producao:hh\\:mm\\:ss},{produto.Tempo_Producao},{produto.Codigo_Resultado}");
            }
        }

        private void btnExecutarSikuli_Click(object sender, EventArgs e)
        {
            try
            {
                string caminhoJava = "java"; // Ou "C:\\caminho\\para\\java.exe"
                string caminhoSikuliJar = "C:\\SikuliX\\sikulixide.jar"; 
                string caminhoScript = "C:\\Users\\anton\\Desktop\\integracao de sistemas\\seu_script.sikuli";

                Process sikuliProcess = new Process();
                sikuliProcess.StartInfo.FileName = caminhoJava;
                sikuliProcess.StartInfo.Arguments = $"-jar \"{caminhoSikuliJar}\" -r \"{caminhoScript}\"";
                sikuliProcess.StartInfo.UseShellExecute = false;
                sikuliProcess.StartInfo.CreateNoWindow = true;
                sikuliProcess.StartInfo.RedirectStandardError = true;

                sikuliProcess.Start();

                // Opcional: esperar conclusão
                // sikuliProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar o script Sikuli: {ex.Message}");
            }
        }

    }
}
