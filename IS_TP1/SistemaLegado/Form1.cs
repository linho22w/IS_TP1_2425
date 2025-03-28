using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace sistema_legado
{
    public partial class Form1 : Form
    {
        private HttpClient client = new HttpClient();
        private string apiBaseUrl = "https://localhost:7008/api/Produto";

        public Form1()
        {
            InitializeComponent();
            ConfigurarHttpClient();
        }

        private void ConfigurarHttpClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void AdicionarProduto(string codigo, string data, string hora, string tempo)
        {
            try
            {
                data = data.Replace('/', '-');
                // Converter a data para o formato yyyy-MM-dd
                var dataConvertida = DateTime.ParseExact(data, "dd-MM-yyyy", null)
                                            .ToString("yyyy-MM-dd");

                var produto = new
                {
                    Codigo_Peca = codigo.PadRight(8).Substring(0, 8),
                    Data_Producao = dataConvertida, // Usa a data convertida
                    Hora_Producao = hora,
                    Tempo_Producao = tempo
                };

                // Resto do método mantido igual
                var json = JsonConvert.SerializeObject(produto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiBaseUrl, content);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Produto registado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos(string codigo, string data, string hora, string tempo)
        {
            string erroMensagem = "";

            // Validação do código
            if (string.IsNullOrWhiteSpace(codigo))
                erroMensagem += "Código da peça obrigatório!\n";
            else if (codigo.Length != 8)
                erroMensagem += "Código deve ter 8 caracteres!\n";
            else if (!codigo.StartsWith("aa") && !codigo.StartsWith("ab") &&
                     !codigo.StartsWith("ba") && !codigo.StartsWith("bb"))
                erroMensagem += "Código deve começar com aa, ab, ba ou bb!\n";

            // Validação da data
            if (string.IsNullOrWhiteSpace(data))
            {
                erroMensagem += "Data não pode estar vazia!\n";
            }
            else
            {
                data = data.Replace('/', '-');

                if (data.Length != 10)
                {
                    erroMensagem += "Data deve ter 10 caracteres (ex: 20-03-2024)!\n";
                }
                else if (!DateTime.TryParseExact(
                    data,
                    "dd-MM-yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out _))
                {
                    erroMensagem += $"Data inválida: {data} (use dd-MM-yyyy)!\n";
                }
            }

            // Validação da hora
            if (!DateTime.TryParseExact(hora, "HH:mm:ss", null,
                System.Globalization.DateTimeStyles.None, out _))
                erroMensagem += "Formato de hora inválido (HH:mm:ss)!\n";

            // Validação do tempo
            if (!int.TryParse(tempo, out int tempoInt) || tempoInt < 10 || tempoInt > 50)
                erroMensagem += "Tempo inválido (10-50 segundos)!\n";

            if (!string.IsNullOrEmpty(erroMensagem))
            {
                MessageBox.Show(erroMensagem, "Erros de Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimparCampos()
        {
            txtCodigo.Clear();
            txtData.Clear();
            txtHora.Clear();
            txtTempo.Clear();
            txtCodigo.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();
                string data = txtData.Text.Trim();
                string hora = txtHora.Text.Trim();
                string tempo = txtTempo.Text.Trim();

                if (ValidarCampos(codigo, data, hora, tempo))
                    AdicionarProduto(codigo, data, hora, tempo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}