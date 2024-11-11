namespace Locadora_Filmes_e_Jogos.Models
{
    public class PedidoViewModel
    {
        public int NumeroLocacao { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public List<Filmes> Filmes { get; set; }
        public List<Jogos> Jogos { get; set; }
    }
}
