namespace Locadora_Filmes_e_Jogos.Models
{
    public class Item_jogo_locacao
    {
        public int fk_locacao { get; set; }
        public Locacao Locacao { get; set; }
        public int fk_jogo { get; set; }
        public Jogos Jogo { get; set; }
    }
}
