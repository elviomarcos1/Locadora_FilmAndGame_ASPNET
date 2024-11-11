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

        public DbSet<Item_filme_locacao> item_filme_locacao { get; set; }

        public DbSet<Item_jogo_locacao> item_jogo_locacao { get; set; }

        //DbSet com chaves estrangeiras
        //locação
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locacao>()
                .HasOne(l => l.Cliente)
                .WithMany(c => c.Locacao)
                .HasForeignKey(l => l.fk_cliente);

            base.OnModelCreating(modelBuilder);


            //Db_Context muitos para muito item_filme_locação com locação
            modelBuilder.Entity<Item_filme_locacao>()
                .HasKey(ifl => new { ifl.fk_locacao, ifl.fk_filme });

            modelBuilder.Entity<Item_filme_locacao>()
                .HasOne(l => l.Locacao)
                .WithMany(ifl => ifl.Item_filme_locacao)
                .HasForeignKey(l => l.fk_locacao);
            modelBuilder.Entity<Item_filme_locacao>()
                .HasOne(f => f.Filme)
                .WithMany(ifl => ifl.Item_filme_locacao)
                .HasForeignKey(f => f.fk_filme);


            //Db_Context muitos para muito item_Jogo_locação com locação
            modelBuilder.Entity<Item_jogo_locacao>()
                .HasKey(ijl => new { ijl.fk_locacao, ijl.fk_jogo });

            modelBuilder.Entity<Item_jogo_locacao>()
                .HasOne(l => l.Locacao)
                .WithMany(ijl => ijl.Item_jogo_locacao)
                .HasForeignKey(l => l.fk_locacao);
            modelBuilder.Entity<Item_jogo_locacao>()
                .HasOne(j => j.Jogo)
                .WithMany(ijl => ijl.Item_jogo_locacao)
                .HasForeignKey(j => j.fk_jogo);

        }
        public DbSet<Locadora_Filmes_e_Jogos.Models.Locacao> Locacao { get; set; } = default!;
    }
}
