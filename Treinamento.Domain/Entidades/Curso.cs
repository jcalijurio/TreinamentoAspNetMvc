using System.Collections.Generic;

namespace Treinamento.Domain.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public decimal Valor { get; set; }
        public int LimiteAlunos { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
