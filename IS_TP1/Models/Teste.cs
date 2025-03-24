using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IS_trabalho.Models
{
    public class Teste
    {
            [Key]
            public int ID_Teste { get; set; }

            [Required]
            [ForeignKey("Produto")]
            public int ID_Produto { get; set; }

            [Required]
            [StringLength(2)]
            public string Codigo_Resultado { get; set; }

            [Required]
            public DateTime Data_Teste { get; set; }
      
    }
}
