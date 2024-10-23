using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora_Filmes_e_Jogos.Models
{
    public class Funcionario
    {
        [Key]
        [DisplayName("ID")]
        public int pk_funcionario { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Este campo só pode ter 100 Caracteres !")]
        [DisplayName("Nome")]
        public string nome_funcionario { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Este campo só pode ter 20 Caracteres !")]
        [DisplayName("CPF")]
        public string cpf_funcionario { get; set; }

        [Required]
        [MaxLength(4, ErrorMessage = "Este campo só pode ter 4 Digitos")]
        [DisplayName("Ano de Nascimento")]
        public int ano_nascimento_funcionario { get; set; }

        [MaxLength(1, ErrorMessage = "Este campo só pode ter 1 Caracteres")]
        [DisplayName("Gênero")]
        public string sexo_funcionario { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Este campo só pode ter 60 Caracteres")]
        [DisplayName("Função")]
        public string funcao_funcionario { get; set; }

        [MaxLength(1, ErrorMessage = "Este campo só pode ter 1 Caracteres")]
        [DisplayName("Ativo")]
        public string ativo_funcionario { get; set; }

    }
}
