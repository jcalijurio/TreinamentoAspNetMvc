using System.Threading.Tasks;
using Treinamento.Domain.Interfaces.Negocio.Base;
using Treinamento.Domain.Interfaces.Repositorio.Base;

namespace Treinamento.Domain.Classes.Negocio.Base
{
    public abstract class CrudNegocio<TDto> : VisualizacaoNegocio<TDto>, ICrudNegocio<TDto>
    {
        private ICrudRepository<TDto> _repository;

        public CrudNegocio(ICrudRepository<TDto> repository) : base(repository)
        {
            _repository = repository;
        }

        public virtual async Task Editar(TDto dto)
        {
            await _repository.Editar(dto);
            await _repository.Commit();
        }

        public virtual async Task Excluir(int id)
        {
            await _repository.Excluir(id);
            await _repository.Commit();
        }

        public virtual async Task Incluir(TDto dto)
        {
            await _repository.Incluir(dto);
            await _repository.Commit();
        }
    }
}
