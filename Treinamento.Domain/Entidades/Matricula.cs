using System.Collections.Generic;

namespace Treinamento.Domain.Entidades
{
    public class Matricula
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual ICollection<ContaReceber> ContasReceber { get; set; }
    }
}
