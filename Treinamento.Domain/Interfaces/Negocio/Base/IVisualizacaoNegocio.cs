using System.Collections.Generic;
using System.Threading.Tasks;

namespace Treinamento.Domain.Interfaces.Negocio.Base
{
    public interface IVisualizacaoNegocio<TDto>
    {
        Task<IEnumerable<TDto>> Listar();
        Task<TDto> ObterPorId(int id);
    }
}
