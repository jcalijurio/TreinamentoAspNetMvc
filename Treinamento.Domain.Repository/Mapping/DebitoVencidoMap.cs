using System.Data.Entity.ModelConfiguration;
using Treinamento.Domain.Entidades;

namespace Treinamento.Domain.Repository.Mapping
{
    public class DebitoVencidoMap : EntityTypeConfiguration<DebitoVencido>
    {
        public DebitoVencidoMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Valor).HasPrecision(10, 2);

            HasRequired(p => p.Aluno)
                .WithMany(p => p.DebitosVencidos)
                .HasForeignKey(p => p.AlunoId);
        }
    }
}
