using System;
using Treinamento.Domain.Entidades;

namespace Treinamento.Domain.Dtos
{
    public class AlunoDto
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual SexoAluno Sexo { get; set; }
        public virtual DateTime DtNascimento { get; set; }
        public virtual int? ConvenioId { get; set; }
    }
}
