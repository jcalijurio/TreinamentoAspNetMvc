using Treinamento.Domain.Classes.Negocio.Base;
using Treinamento.Domain.Dtos;
using Treinamento.Domain.Interfaces.Negocio;
using Treinamento.Domain.Interfaces.Repositorio;

namespace Treinamento.Domain.Classes.Negocio
{
    public class MatriculaNegocio : CrudNegocio<MatriculaDto>, IMatriculaNegocio
    {
        public MatriculaNegocio(IMatriculaRepository repository) : base(repository)
        {
        }
    }
}
