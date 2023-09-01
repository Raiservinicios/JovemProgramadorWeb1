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

            builder.HasKey(t => t.Cod);

            builder.Property(t => t.NomeUsuario).HasColumnType("varchar(50)");

            builder.Property(t => t.Senha).HasColumnType("varchar(50)");
        }
    }
}

