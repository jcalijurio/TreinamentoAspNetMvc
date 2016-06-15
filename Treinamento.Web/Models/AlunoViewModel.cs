using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Treinamento.Domain.Dtos;
using Treinamento.Domain.Entidades;

namespace Treinamento.Web.Models
{
    public class AlunoViewModel : AlunoDto
    {
        [Required(ErrorMessage = "Obrigatório"), DisplayName("Nome")]
        public override string Nome { get; set; }

        [DisplayName("Convênio")]
        public override int? ConvenioId { get; set; }

        [MaxLength(11, ErrorMessage = "Cpf inválido"), Required(ErrorMessage = "Obrigatório"), DisplayName("CPF")]
        public override string Cpf { get; set; }

        [Required(ErrorMessage = "Obrigatório"), DisplayName("Data Nascimento")]
        public override DateTime DtNascimento { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        public override SexoAluno Sexo { get; set; }
    }
}