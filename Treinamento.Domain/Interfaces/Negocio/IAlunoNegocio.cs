using System.Collections.Generic;
using System.Threading.Tasks;
using Treinamento.Domain.Dtos;
using Treinamento.Domain.Interfaces.Negocio.Base;

namespace Treinamento.Domain.Interfaces.Negocio
{
    public interface IAlunoNegocio : ICrudNegocio<AlunoDto>
    {
        Task<IEnumerable<ComboDto>> ListarConvenios();
    }
}
