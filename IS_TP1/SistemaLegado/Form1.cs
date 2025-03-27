using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace sistema_legado
{
    public partial class Form1 : Form
    {
        private DataTable tabelaProdutos = new DataTable();

        // String de conexão com o banco de dados (ajuste conforme necessário)
        string connectionString = "Data Source=localhost\\MEIBI2025;Initial Catalog=Producao;Integrated Security=True;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private List<Produto> produtos = new List<Produto>();
        private string caminhoFicheiro = "C:\\Users\\anton\\Desktop\\integracao de sistemas\\dados.txt";
        public Form1()
        {
            InitializeComponent();
            ConfigurarTabela();
            CarregarDadosDoBanco();

            dtData.Value = new DateTime(2000, 1, 1);
            dtHora.Value = new DateTime(2000, 1, 1, 0, 0, 0);
        }

        private void ConfigurarTabela()
        {
            gridProdutos.DataSource = tabelaProdutos;
        }

        private bool ValidarCampos(string codigo, string tempo)
        {
            if (string.IsNullOrWhiteSpace(codigo) || codigo.Length != 8)
            {
                MessageBox.Show("O código da peça deve ter exatamente 8 caracteres!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Preencha o código da peça!");
                return false;
            }

            if (!int.TryParse(tempo, out _))
            {
                MessageBox.Show("Tempo deve ser um número!");
                return false;
            }

            return true;
        }

        private void AdicionarProduto(string codigo, DateTime data, TimeSpan hora, string tempo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InserirProduto", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Garante que o código tenha 8 caracteres
                        cmd.Parameters.AddWithValue("@Codigo_Peca", codigo.PadRight(8).Substring(0, 8));
                        cmd.Parameters.AddWithValue("@Data_Producao", data.Date);
                        cmd.Parameters.AddWithValue("@Hora_Producao", hora);
                        cmd.Parameters.AddWithValue("@Tempo_Producao", int.Parse(tempo));

                        cmd.ExecuteNonQuery();
                    }

                    CarregarDadosDoBanco(); // Atualiza a grade
                    MessageBox.Show("Produto inserido com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao inserir produto: {ex.Message}");
                }
            }
        }

        private void LimparCampos(TextBox codigo, TextBox tempo)
        {
            codigo.Clear();
            tempo.Clear();
        }
        private void CarregarDadosDoBanco()
        {
            tabelaProdutos.Rows.Clear(); // Limpa dados antigos

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Produto";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(tabelaProdutos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação dos campos
                string codigo = txtCodigo.Text.Trim();
                string tempo = txtTempo.Text.Trim();

                if (string.IsNullOrEmpty(codigo) || codigo.Length != 8)
                {
                    MessageBox.Show("O código deve ter 8 caracteres!");
                    return;
                }

                if (!int.TryParse(tempo, out int tempoValor))
                {
                    MessageBox.Show("Tempo deve ser um número!");
                    return;
                }
                DateTime dataProducao = dtData.Value == DateTime.MinValue ? new DateTime(2000, 1, 1) : dtData.Value;
                TimeSpan horaProducao = dtHora.Value == DateTime.MinValue ? new TimeSpan(0, 0, 0) : dtHora.Value.TimeOfDay;
                // Chama o método de inserção
                AdicionarProduto(codigo, dtData.Value, dtHora.Value.TimeOfDay, tempo);
                LimparCampos(txtCodigo, txtTempo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}");
            }
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
                sw.WriteLine($"{produto.Codigo_Peca},{produto.Data_Producao:dd-MM-yyyy},{produto.Hora_Producao:hh\\:mm\\:ss},{produto.Tempo_Producao},{produto.Codigo_Resultado}");
            }
        }

        private async void btnExecutarSikuli_Click(object sender, EventArgs e)
        {
            string caminhoSikuliX = @"C:\Users\anton\Downloads\sikulixide-2.0.5.jar";
            string caminhoScript = @"C:\Users\anton\Downloads\sikuli_IS.sikuli\sikuli_IS.py";
            string caminhoDados = @"C:\Users\anton\Desktop\integracao de sistemas\dados.txt";

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
                MessageBox.Show(saida, "Resultado do SikuliX");
            }
        }

    }

}



