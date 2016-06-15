using System.Data.Entity.ModelConfiguration;
using Treinamento.Domain.Entidades;

namespace Treinamento.Domain.Mapping
{
    public class MatriculaMap : EntityTypeConfiguration<Matricula>
    {
        public MatriculaMap()
        {
            HasKey(p => p.Id);

            HasRequired(p => p.Aluno)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(p => p.AlunoId);

            HasRequired(p => p.Turma)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(p => p.TurmaId);
        }
    }
}
