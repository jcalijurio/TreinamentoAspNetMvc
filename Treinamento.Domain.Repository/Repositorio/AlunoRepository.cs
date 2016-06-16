using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Treinamento.Domain.Dtos;
using Treinamento.Domain.Entidades;
using Treinamento.Domain.Interfaces.Repositorio;
using Treinamento.Domain.Repository.Contexto;

namespace Treinamento.Domain.Repository.Repositorio
{
    public class AlunoRepository : IAlunoRepository
    {
        private TreinamentoContexto _contexto;

        public AlunoRepository(TreinamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Commit()
        {
            await _contexto.SaveChangesAsync();
        }

        public async Task Editar(AlunoDto dto)
        {
            var aluno = await _contexto.Alunos.FindAsync(dto.Id);
            aluno.Nome = dto.Nome;
            aluno.ConvenioId = dto.ConvenioId;
            aluno.Cpf = dto.Cpf;
            aluno.DtNascimento = dto.DtNascimento;
            aluno.Nome = dto.Nome;
            aluno.Sexo = dto.Sexo;
        }

        public async Task Excluir(int id)
        {
            var aluno = await _contexto.Alunos.FindAsync(id);
            _contexto.Alunos.Remove(aluno);
        }

        public async Task Incluir(AlunoDto dto)
        {
            var aluno = new Aluno
            {
                ConvenioId = dto.ConvenioId,
                Cpf = dto.Cpf,
                DtNascimento = dto.DtNascimento,
                Nome = dto.Nome,
                Sexo = dto.Sexo
            };
            _contexto.Alunos.Add(aluno);
        }

        public async Task<IEnumerable<AlunoDto>> Listar()
        {
            var retorno = await (from a in _contexto.Alunos
                                 select new AlunoDto
                                 {
                                     ConvenioId = a.ConvenioId,
                                     Cpf = a.Cpf,
                                     DtNascimento = a.DtNascimento,
                                     Id = a.Id,
                                     Nome = a.Nome,
                                     Sexo = a.Sexo
                                 }).ToArrayAsync();
            return retorno;
        }

        public async Task<IEnumerable<ComboDto>> ListarConvenios()
        {
            var retorno = await (from c in _contexto.Convenios
                                 orderby c.Nome ascending
                                 select new ComboDto
                                 {
                                     Id = c.Id,
                                     Valor = c.Nome
                                 }).ToArrayAsync();

            return retorno;
        }

        public async Task<AlunoDto> ObterPorId(int id)
        {
            var retorno = await (from a in _contexto.Alunos
                                 where a.Id == id
                                 select new AlunoDto
                                 {
                                     ConvenioId = a.ConvenioId,
                                     Cpf = a.Cpf,
                                     DtNascimento = a.DtNascimento,
                                     Id = a.Id,
                                     Nome = a.Nome,
                                     Sexo = a.Sexo
                                 }).FirstOrDefaultAsync();
            return retorno;
        }
    }
}
