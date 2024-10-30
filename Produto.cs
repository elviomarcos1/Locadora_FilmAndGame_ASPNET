namespace Locadora_Filmes_e_Jogos
{
    public abstract class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Classificacao { get; set; }
        public int AnoLancamento { get; set; }
        public string Ativo { get; set; }

    }
}
