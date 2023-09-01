using JovemProgramadorWeb1.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWeb1.Data.Mapeamento
{
    public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(t => t.Codigo);

            builder.Property(t => t.Nome).HasColumnType("varchar(50)");
            builder.Property(t => t.Email).HasColumnType("varchar(50)");
            builder.Property(t => t.CPF).HasColumnType("varchar(11)");
            builder.Property(t => t.Idade).HasColumnType("int");
            builder.Property(t => t.Matricula).HasColumnType("varchar(20)");
        }
    }
}
