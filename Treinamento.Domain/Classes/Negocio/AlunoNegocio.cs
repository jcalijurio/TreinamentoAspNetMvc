using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Treinamento.Domain.Classes.Negocio.Base;
using Treinamento.Domain.Dtos;
using Treinamento.Domain.Interfaces.Negocio;
using Treinamento.Domain.Interfaces.Repositorio;

namespace Treinamento.Domain.Classes.Negocio
{
    public class AlunoNegocio : CrudNegocio<AlunoDto>, IAlunoNegocio
    {
        private IAlunoRepository _repository;

        public AlunoNegocio(IAlunoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ComboDto>> ListarConvenios()
        {
            return await _repository.ListarConvenios();
        }
    }
}
