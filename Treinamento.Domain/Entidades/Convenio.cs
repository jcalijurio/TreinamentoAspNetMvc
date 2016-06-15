using System.Collections.Generic;

namespace Treinamento.Domain.Entidades
{
    public class Convenio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Desconto { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
