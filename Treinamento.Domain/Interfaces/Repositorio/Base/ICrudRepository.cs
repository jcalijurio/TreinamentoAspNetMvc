using System.Threading.Tasks;

namespace Treinamento.Domain.Interfaces.Repositorio.Base
{
    public interface ICrudRepository<TDto> : IVisualizacaoRepository<TDto>
    {
        Task Incluir(TDto dto);
        Task Editar(TDto dto);
        Task Excluir(int id);
    }
}
