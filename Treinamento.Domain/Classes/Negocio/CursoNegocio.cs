using Treinamento.Domain.Classes.Negocio.Base;
using Treinamento.Domain.Dtos;
using Treinamento.Domain.Interfaces.Negocio;
using Treinamento.Domain.Interfaces.Repositorio;

namespace Treinamento.Domain.Classes.Negocio
{
    public class CursoNegocio : CrudNegocio<CursoDto>, ICursoNegocio
    {
        private ICursoRepository _repository;

        public CursoNegocio(ICursoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
