using Capta.Domain;
using Capta.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Capta.Repository
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole,
                                                IdentityUserLogin<int>, IdentityRoleClaim<int>, 
                                                IdentityUserToken<int>>
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>{
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                
            });

            modelBuilder.Entity<JogadorHabilidade>()
                .HasKey(jh => new { jh.HabilidadeId, jh.JogadorId });
        }
    }
}