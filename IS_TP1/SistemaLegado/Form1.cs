using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace sistema_legado
{
    public partial class Form1 : Form
    {
        private DataTable tabelaProdutos = new DataTable();

        // String de conexão com a base de dados
        string connectionString = "Data Source=localhost\\MEIBI2025;Initial Catalog=Producao;Integrated Security=True;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public Form1()
        {
            InitializeComponent();
            ConfigurarTabela();
         
            CarregarDadosDaBD();

            dtData.Value = new DateTime(2000, 1, 1);
            dtHora.Value = new DateTime(2000, 1, 1, 0, 0, 0);
        }

        private void ConfigurarTabela()
        {
            gridProdutos.DataSource = tabelaProdutos;
        }

        private bool ValidarCampos(string codigo, string tempo)
        {
            string erroMensagem = "";

            // Verificar se o código da peça é válido
            if (string.IsNullOrWhiteSpace(codigo))
            {
                erroMensagem = "O código da peça não pode estar vazio!";
            }
            else if (codigo.Length != 8)
            {
                erroMensagem = "O código da peça deve ter exatamente 8 caracteres!";
            }
            else
            {
                string prefixo = codigo.Substring(0, 2);
                if (prefixo != "aa" && prefixo != "ab" && prefixo != "ba" && prefixo != "bb")
                {
                    erroMensagem = "Os dois primeiros caracteres do código devem ser: 'aa', 'ab', 'ba' ou 'bb'.";
                }
            }

            // Verificar se o tempo de produção é válido
            if (string.IsNullOrWhiteSpace(tempo))
            {
                erroMensagem = "O tempo de produção não pode estar vazio!";
            }
            else if (!int.TryParse(tempo, out int tempoInt) || tempoInt < 10 || tempoInt > 50)
            {
                erroMensagem = "O tempo de produção deve ser um número inteiro entre 10 e 50 segundos!";
            }

            // Se houver erro, exibe a mensagem e retorna false
            if (!string.IsNullOrEmpty(erroMensagem))
            {
                MessageBox.Show(erroMensagem, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    CarregarDadosDaBD(); // Atualiza a grade
                    MessageBox.Show("Produto registado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparCampos(TextBox codigo, TextBox tempo)
        {
            codigo.Clear();
            tempo.Clear();
        }

        private void CarregarDadosDaBD()
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação dos campos
                string codigo = txtCodigo.Text.Trim();
                string tempo = txtTempo.Text.Trim();

                // Validar campos antes de inserir
                if (!ValidarCampos(codigo, tempo))
                {
                    return; // Se a validação falhar, sai da função
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
    }

}



