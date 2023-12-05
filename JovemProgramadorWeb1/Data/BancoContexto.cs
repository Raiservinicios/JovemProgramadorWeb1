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
            modelBuilder.Entity<Evento>().HasKey(e => e.codigo);
            modelBuilder.Entity<Participacao>().HasKey(e => e.codigo);
            //modelBuilder.Entity<Usuario>().HasNoKey();
            modelBuilder.Entity<Usuario>().HasKey(u => u.codigo); 
            modelBuilder.Entity<Socio>().HasNoKey();
            modelBuilder.Entity<Fatura>().HasNoKey();
        }
        

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Socio> Socio { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Participacao> Participacao { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
    }
}

