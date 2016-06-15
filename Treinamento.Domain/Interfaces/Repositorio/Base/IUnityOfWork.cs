using System.Threading.Tasks;

namespace Treinamento.Domain.Interfaces.Repositorio.Base
{
    public interface IUnityOfWork
    {
        Task Commit();
    }
}
