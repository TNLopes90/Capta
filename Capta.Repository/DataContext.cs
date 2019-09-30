using Microsoft.EntityFrameworkCore;
using Capta.Domain;

namespace Capta.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option)
        : base(option)
        {
        }

        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<JogadorHabilidade> JogadoresHabilidades { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<Time> Times { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JogadorHabilidade>()
                .HasKey(jh => new { jh.HabilidadeId, jh.JogadorId });
        }
    }
}