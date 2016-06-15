using Treinamento.Domain.Dtos;
using Treinamento.Domain.Interfaces.Repositorio.Base;

namespace Treinamento.Domain.Interfaces.Repositorio
{
    public interface ICursoRepository : ICrudRepository<CursoDto>
    {
    }
}
