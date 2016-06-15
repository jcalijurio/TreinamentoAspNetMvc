using System.Collections.Generic;
using System.Threading.Tasks;
using Treinamento.Domain.Interfaces.Negocio.Base;
using Treinamento.Domain.Interfaces.Repositorio.Base;

namespace Treinamento.Domain.Classes.Negocio.Base
{
    public abstract class VisualizacaoNegocio<TDto> : IVisualizacaoNegocio<TDto>
    {
        private IVisualizacaoRepository<TDto> _repository;

        public VisualizacaoNegocio(IVisualizacaoRepository<TDto> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<TDto>> Listar()
        {
            return await _repository.Listar();
        }

        public virtual async Task<TDto> ObterPorId(int id)
        {
            return await _repository.ObterPorId(id);
        }
    }
}
