using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora_Filmes_e_Jogos.Models
{
    public class Filmes
    {
        [Key]
        [DisplayName("ID")]
        public int pk_filmes { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Este campo só pode ter 100 Caracteres !")]
        [DisplayName("Filme")]
        public string nome_filme { get; set; }

        [DisplayName("Classificação")]
        public int classificacao_filme { get; set; }

        [Required]
        [DisplayName("Lançamento")]
        public int ano_lancamento_filmes { get; set; }

        [DisplayName("Nota")]
        public decimal nota_filme { get; set; }

        [MaxLength(1, ErrorMessage = "Este campo só pode ter 1 Caracteres")]
        [DisplayName("Ativo")]
        public string ativo_filmes { get; set; }

        public ICollection<Item_filme_locacao>? Item_film { get; set; }
    }
}
