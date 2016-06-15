using System.Collections.Generic;
using System.Threading.Tasks;

namespace Treinamento.Domain.Interfaces.Repositorio.Base
{
    public interface IVisualizacaoRepository<TDto> : IUnityOfWork
    {
        Task<IEnumerable<TDto>> Listar();
        Task<TDto> ObterPorId(int id);
    }
}
