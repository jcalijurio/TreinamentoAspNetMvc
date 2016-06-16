using System.Data.Entity.ModelConfiguration;
using Treinamento.Domain.Entidades;

namespace Treinamento.Domain.Repository.Mapping
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasRequired(p => p.Curso)
                .WithMany(p => p.Turmas)
                .HasForeignKey(p => p.CursoId);
        }
    }
}
