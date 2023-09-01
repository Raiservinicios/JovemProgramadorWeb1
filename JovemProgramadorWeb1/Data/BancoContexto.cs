using JovemProgramadorWeb1.Data.Mapeamento;
using JovemProgramadorWeb1.Models;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWeb1.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapeamento());
            modelBuilder.Entity<Usuario>()
                .HasNoKey();
        }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
