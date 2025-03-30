using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;

namespace sistema_legado
{
    public partial class Form1 : Form
    {
        private HttpClient client = new HttpClient();
        private string apiBaseUrl = "http://localhost:5077/api/Produto";

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
                // Validações básicas
                if (string.IsNullOrWhiteSpace(codigo))
                    throw new ArgumentException("Código da peça é obrigatório");

                if (!int.TryParse(tempo, out int tempoProducao) || tempoProducao < 10 || tempoProducao > 50)
                    throw new ArgumentException("Tempo de produção deve ser entre 10 e 50");

                // Formatação da data (DD/MM/AAAA -> AAAA-MM-DD)
                DateTime dataProducao;
                if (!DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataProducao))
                    throw new ArgumentException("Formato de data inválido. Use DD/MM/AAAA");

                // Formatação da hora (garante HH:MM:SS)
                TimeSpan horaProducao;
                if (!TimeSpan.TryParseExact(hora, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out horaProducao))
                {
                    if (!TimeSpan.TryParseExact(hora, "hh\\:mm", CultureInfo.InvariantCulture, out horaProducao))
                        throw new ArgumentException("Formato de hora inválido. Use HH:MM ou HH:MM:SS");
                }

                // Objeto no formato exato que a API espera
                var payload = new
                {
                    Produto = new
                    {
                        Codigo_Peca = codigo.Trim(),
                        Data_Producao = dataProducao.ToString("yyyy-MM-dd"),
                        Hora_Producao = horaProducao.ToString("hh\\:mm\\:ss"),
                        Tempo_Producao = tempoProducao
                    }
                };

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiBaseUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    var errorObj = JsonConvert.DeserializeObject<dynamic>(errorContent);
                    throw new HttpRequestException(errorObj?.message?.ToString() ?? "Erro na API");
                }

                MessageBox.Show("Produto registado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro de Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message, "Erro na API",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    erroMensagem += "Data deve ter 10 caracteres (ex: 20-03-2025)!\n";
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

        private void btnGuardar_Click(object sender, EventArgs e)
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



