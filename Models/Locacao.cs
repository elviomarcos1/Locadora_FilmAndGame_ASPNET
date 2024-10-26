using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora_Filmes_e_Jogos.Models
{
    public class Locacao
    {
        [Key]
        [DisplayName("ID")]
        public int pk_locacao { get; set; }

        [Required]
        [DisplayName("Cliente")]
        public int fk_cliente { get; set; }

        [DisplayName("Data da Locação")]
        public DateTime data_locacao { get; set; }

        [DisplayName("Data da Devolução Prevista")]
        public DateTime data_devolucao_prevista { get; set; }

        [DisplayName("Data da Devolução")]
        public DateTime devolucao_real { get; set; }

        //Navegação para a tabela Cliente
        public Cliente Cliente { get; set; }
    }
}
