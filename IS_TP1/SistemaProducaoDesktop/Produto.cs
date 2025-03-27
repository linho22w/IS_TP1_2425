using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProducaoDesktop
{
    public class Produto
    {
        public string Codigo_Peca { get; set; }
        public DateTime Data_Producao { get; set; }
        public TimeSpan Hora_Producao { get; set; } 
        public int Tempo_Producao { get; set; }
        public string Codigo_Resultado { get; set; }

        private static readonly Random random = new Random();

        public static Produto GerarProdutoAleatorio()
        {
            string[] tiposProduto = { "aa", "ab", "ba", "bb" };
            string tipo = tiposProduto[random.Next(tiposProduto.Length)];
            string identificador = Guid.NewGuid().ToString("N").Substring(0, 6); // Gera um identificador único de 6 caracteres
            //No entanto poderia ser utilizado - random.Next(100000, 999999).ToString(); | Com poucas possibilidades de calhar o mesmo id.
            //Como fala em caracteres podemos utilizar Guid que fica mais correto,
            //aceitando numeros e letras (nos restantes 6 digitos do codigo).
            string codigoPeca = tipo + identificador;

            DateTime dataProducao = DateTime.Now.Date;
            TimeSpan horaProducao = DateTime.Now.TimeOfDay;
            int tempoProducao = random.Next(10, 51); // Entre 10s e 50s


            //OLD - Distribuiçao completamente aleatoria dos codigos de resultado
            //string[] codigosResultado = { "01", "02", "03", "04", "05", "06" };
            //string codigoResultado = codigosResultado[random.Next(codigosResultado.Length)];
            //

            // Distribuição realista dos códigos de resultado
            
            string codigoResultado = GerarCodigoResultado();

            return new Produto
            {
                Codigo_Peca = codigoPeca,
                Data_Producao = dataProducao,
                Hora_Producao = horaProducao,
                Tempo_Producao = tempoProducao,
                Codigo_Resultado = codigoResultado
            };
        }

        // Método para gerar código de resultado com distribuição realista
        private static string GerarCodigoResultado()
        {
            int chance = random.Next(100); // Número entre 0 e 99

            if (chance < 70)
                return "01"; // 70% de chance de ser "01 - Ok"
            else if (chance < 75)
                return "02"; // 5% para "02 - Falha na inspeção visual"
            else if (chance < 80)
                return "03"; // 5% para "03 - Falha na inspeção de resistência):"
            else if (chance < 85)
                return "04"; // 5% para "04 - Falha na inspeção de dimensões):"
            else if (chance < 90)
                return "05"; // 5% para "05 - Falha na inspeção de estanqueidade"
            else
                return "06"; // 5% para "06 - Desconhecido"
        }
    }
}
