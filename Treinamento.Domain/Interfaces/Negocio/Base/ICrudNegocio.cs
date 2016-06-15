using System.Threading.Tasks;

namespace Treinamento.Domain.Interfaces.Negocio.Base
{
    public interface ICrudNegocio<TDto> : IVisualizacaoNegocio<TDto>
    {
        Task Incluir(TDto dto);
        Task Editar(TDto dto);
        Task Excluir(int id);
    }
}
