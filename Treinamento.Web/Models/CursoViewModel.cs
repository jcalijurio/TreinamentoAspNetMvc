using System.ComponentModel.DataAnnotations;
using Treinamento.Domain.Dtos;

namespace Treinamento.Web.Models
{
    public class CursoViewModel : CursoDto
    {
        [Required(ErrorMessage = "Obrigatório"), Display(Name = "CursoNome", ResourceType = typeof(Termos))]
        public override string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório"), Range(5, 40, ErrorMessage = "Quantidade inválida")]
        [Display(Name = "CursoLimiteAlunos", ResourceType = typeof(Termos))]
        public override int LimiteAlunos { get; set; }
    }
}