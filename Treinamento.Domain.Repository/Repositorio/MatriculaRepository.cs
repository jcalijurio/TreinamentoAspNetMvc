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
    public class MatriculaRepository : IMatriculaRepository
    {
        private TreinamentoContexto _contexto;

        public MatriculaRepository(TreinamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Commit()
        {
            await _contexto.SaveChangesAsync();
        }

        public async Task Editar(MatriculaDto dto)
        {
            var ma = await _contexto.Matriculas.FindAsync(dto.Id);
            ma.AlunoId = dto.AlunoId;
            ma.TurmaId = dto.TurmaId;
        }

        public async Task Excluir(int id)
        {
            var ma = await _contexto.Matriculas.FindAsync(id);
            _contexto.Matriculas.Remove(ma);
        }

        public async Task Incluir(MatriculaDto dto)
        {
            var ma = new Matricula
            {
                AlunoId = dto.AlunoId,
                Id = dto.Id,
                TurmaId = dto.TurmaId
            };

            _contexto.Matriculas.Add(ma);
        }

        public async Task<IEnumerable<MatriculaDto>> Listar()
        {
            var retorno = from ma in _contexto.Matriculas
                          join a in _contexto.Alunos on ma.AlunoId equals a.Id
                          join t in _contexto.Turmas on ma.TurmaId equals t.Id
                          join c in _contexto.Cursos on t.CursoId equals c.Id
                          orderby ma.Id descending
                          select new MatriculaDto
                          {
                              Id = ma.Id,
                              AlunoId = ma.AlunoId,
                              TurmaId = ma.TurmaId,
                              CursoId = t.CursoId,
                              Aluno = a.Nome,
                              Turma = t.Numero,
                              Curso = c.Nome
                          };

            return await retorno.ToArrayAsync();
        }

        public async Task<MatriculaDto> ObterPorId(int id)
        {
            var retorno = from ma in _contexto.Matriculas
                          where ma.Id == id
                          select new MatriculaDto
                          {
                              Id = ma.Id,
                              AlunoId = ma.AlunoId,
                              TurmaId = ma.TurmaId
                          };

            return await retorno.FirstOrDefaultAsync();
        }
    }
}
