using System.Data.Entity.ModelConfiguration;
using Treinamento.Domain.Entidades;

namespace Treinamento.Domain.Repository.Mapping
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(p => p.Nome).HasMaxLength(100);
            Property(p => p.Cpf).HasMaxLength(14);

            HasOptional(p => p.Convenio)
                .WithMany(p => p.Alunos)
                .HasForeignKey(p => p.ConvenioId);
        }
    }
}
