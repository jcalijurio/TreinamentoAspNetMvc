using System.Collections.Generic;
using System.Threading.Tasks;
using Treinamento.Domain.Dtos;
using Treinamento.Domain.Interfaces.Repositorio.Base;

namespace Treinamento.Domain.Interfaces.Repositorio
{
    public interface ICursoRepository : ICrudRepository<CursoDto>
    {
        Task<IEnumerable<ComboDto>> ListarTurmas(int cursoId);
    }
}
