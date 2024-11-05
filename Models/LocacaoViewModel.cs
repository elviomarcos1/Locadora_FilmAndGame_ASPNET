namespace Locadora_Filmes_e_Jogos.Models
{
    public class LocacaoViewModel
    {
        public IEnumerable<Filmes> Filmes { get; set; }
        public IEnumerable<Jogos> Jogos { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }

    }
}
