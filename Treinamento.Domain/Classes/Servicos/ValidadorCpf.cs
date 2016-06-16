using Treinamento.Domain.Interfaces.Repositorio;
using Treinamento.Domain.Interfaces.Servicos;

namespace Treinamento.Domain.Classes.Servicos
{
    public class ValidadorCpf : IValidadorDocumento
    {
        private IAlunoRepository _repository;

        public ValidadorCpf(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public bool Validar(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento) || documento.Length != 11)
                return false;

            documento = documento.Trim().ToLower();
            return !_repository.ValidarDuplicidadeCpf(documento);
        }
    }
}
