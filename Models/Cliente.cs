using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora_Filmes_e_Jogos.Models
{
    public class Cliente
    {
        [Key]
        [DisplayName("ID")]
        public int pk_cliente { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Este campo só pode ter 100 Caracteres !")]
        [DisplayName("Nome")]
        public string nome_cliente { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Este campo só pode ter 20 Caracteres !")]
        [DisplayName("CPF")]
        public string cpf_cliente { get; set; }

        [Required]
        [MaxLength(4, ErrorMessage = "O ano não pode ter mais de 4 Digitos")]
        [DisplayName("Ano de Nascimento")]
        public int ano_nascimento_cliente { get; set; }

        [MaxLength(1, ErrorMessage = "Este campo só aceita 1 character")]
        [DisplayName("Gênero")]
        public string sexo_cliente { get; set; }

        [MaxLength(1, ErrorMessage = "Este campo só aceita 1 character")]
        [DisplayName("Ativo")]
        public string ativo_cliente { get; set; }
    }
}
