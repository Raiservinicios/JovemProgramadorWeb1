using JovemProgramadorWeb1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JovemProgramadorWeb1.Data.Mapeamento
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(t => t.codigo);

            builder.Property(t => t.nomeUsuario).HasColumnType("varchar(50)");

            builder.Property(t => t.senha).HasColumnType("varchar(50)");

<<<<<<< HEAD
            builder.Property(t => t.respostaSeguranca).HasColumnType("varchar(100)");

            builder.Property(t => t.perguntaSeguranca).HasColumnType("varchar(100)");

=======
            builder.Property(t => t.respostaSeguranca).HasColumnType("varchar(50)");
>>>>>>> Vinicios_Branch
        }
    }
}

