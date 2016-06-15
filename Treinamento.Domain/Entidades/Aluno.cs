using System;
using System.Collections.Generic;

namespace Treinamento.Domain.Entidades
{
    public enum SexoAluno
    {
        Masculino = 0,
        Feminino = 1,
        Biru = 2
    }

    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public SexoAluno Sexo { get; set; }
        public DateTime DtNascimento { get; set; }
        public int? ConvenioId { get; set; }

        public virtual Convenio Convenio { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<DebitoVencido> DebitosVencidos { get; set; }
    }
}
