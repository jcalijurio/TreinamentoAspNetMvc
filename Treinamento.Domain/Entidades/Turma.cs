using System;
using System.Collections.Generic;

namespace Treinamento.Domain.Entidades
{
    public class Turma
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime DtInicio { get; set; }
        public int CursoId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
