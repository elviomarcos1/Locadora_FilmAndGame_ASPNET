using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora_Filmes_e_Jogos.Models
{
    public class Jogos
    {
        [Key]
        [DisplayName("ID")]
        public int pk_jogo { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Este campo só pode ter 100 Caracteres !")]
        [DisplayName("Jogo")]
        public string nome_jogo { get; set; }

        [DisplayName("Classificação")]
        public int classificacao_jogo { get; set; }

        [Required]
        [DisplayName("Lançamento")]
        public int ano_lancamento_jogo { get; set; }

        [MaxLength(1, ErrorMessage = "Este campo só pode ter 1 Caracteres")]
        [DisplayName("Ativo")]
        public string ativo_jogos { get; set; }

        public ICollection<Item_jogo_locacao>? Item_jogo_locacao { get; set; }
    }
}
