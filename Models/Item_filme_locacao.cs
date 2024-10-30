namespace Locadora_Filmes_e_Jogos.Models
{
    public class Item_filme_locacao
    {
        public int fk_locacao { get; set; }
        public Locacao Locacao { get; set; }
        public int fk_filme { get; set; }
        public Filmes Filme { get; set; }
    }
}
