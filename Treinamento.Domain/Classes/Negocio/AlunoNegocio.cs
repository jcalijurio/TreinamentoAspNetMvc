using System.Collections.Generic;
using System.Threading.Tasks;
using Treinamento.Domain.Classes.Negocio.Base;
using Treinamento.Domain.Dtos;
using Treinamento.Domain.Excecoes;
using Treinamento.Domain.Interfaces.Negocio;
using Treinamento.Domain.Interfaces.Repositorio;
using Treinamento.Domain.Interfaces.Servicos;

namespace Treinamento.Domain.Classes.Negocio
{
    public class AlunoNegocio : CrudNegocio<AlunoDto>, IAlunoNegocio
    {
        private IAlunoRepository _repository;
        private IValidadorDocumento _validadorDocumento;

        public AlunoNegocio(IAlunoRepository repository, IValidadorDocumento validadorDocumento) : base(repository)
        {
            _repository = repository;
            _validadorDocumento = validadorDocumento;
        }

        public async Task<IEnumerable<ComboDto>> ListarConvenios()
        {
            return await _repository.ListarConvenios();
        }

        public override Task Incluir(AlunoDto dto)
        {
            if (!_validadorDocumento.Validar(dto.Cpf))
                throw new DocumentoInvalidoException();

            return base.Incluir(dto);
        }
    }
}
