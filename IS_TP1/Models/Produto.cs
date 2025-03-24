using System.ComponentModel.DataAnnotations;

namespace IS_trabalho.Models
{
        public class Produto
        {
            [Key]
            public int ID_Produto { get; set; }

            
            [StringLength(8)]
            public string Codigo_Peca { get; set; }

            public DateTime Data_Producao { get; set; }

            
            public TimeSpan Hora_Producao { get; set; }

            
            [Range(10, 50)]
            public int Tempo_Producao { get; set; }
        }
}
