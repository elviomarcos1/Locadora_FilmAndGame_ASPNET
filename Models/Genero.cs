using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora_Filmes_e_Jogos.Models
{
    public class Genero
    {
        [Key]
        [DisplayName("ID")]
        public int pk_genero { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Este campo só pode ter 100 Caracteres !")]
        [DisplayName("Genero")]
        public string nome_genero { get; set; }
    }
}
