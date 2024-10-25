using Locadora_Filmes_e_Jogos.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora_Filmes_e_Jogos.Data
{
    public class applicationDbContext:DbContext
    {
        public applicationDbContext(DbContextOptions<applicationDbContext> option) : base(option) { }

        public DbSet<Cliente> cliente { get; set; }

        public DbSet<Filmes> filmes { get; set; }

        public DbSet<Funcionario> funcionario { get; set; }

        public DbSet<Genero> genero { get; set; }

        public DbSet<Jogos> jogos { get; set; }

    }
}
