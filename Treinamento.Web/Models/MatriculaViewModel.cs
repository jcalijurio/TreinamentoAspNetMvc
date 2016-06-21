using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Treinamento.Domain.Dtos;

namespace Treinamento.Web.Models
{
    public class MatriculaViewModel : MatriculaDto
    {
        [Required(ErrorMessage = "Obrigatório")]
        [DisplayName("Aluno")]
        public override int AlunoId { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [DisplayName("Turma")]
        public override int TurmaId { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [DisplayName("Curso")]
        public override int CursoId { get; set; }
    }
}