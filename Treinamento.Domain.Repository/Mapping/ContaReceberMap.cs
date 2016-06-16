using System.Data.Entity.ModelConfiguration;
using Treinamento.Domain.Entidades;

namespace Treinamento.Domain.Repository.Mapping
{
    public class ContaReceberMap : EntityTypeConfiguration<ContaReceber>
    {
        public ContaReceberMap()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.Valor).HasPrecision(10, 2);

            HasRequired(p => p.Matricula)
                .WithMany(p => p.ContasReceber)
                .HasForeignKey(p => p.MatriculaId);
        }
    }
}
