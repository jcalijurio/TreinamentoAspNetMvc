using System.Collections.Generic;
using System.Threading.Tasks;
using Treinamento.Domain.Dtos;
using Treinamento.Domain.Interfaces.Repositorio.Base;

namespace Treinamento.Domain.Interfaces.Repositorio
{
    public interface IAlunoRepository : ICrudRepository<AlunoDto>
    {
        Task<IEnumerable<ComboDto>> ListarConvenios();
    }
}
