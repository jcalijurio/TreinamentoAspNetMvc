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
    public class CursoRepository : ICursoRepository
    {
        private TreinamentoContexto _contexto;

        public CursoRepository(TreinamentoContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Commit()
        {
            await _contexto.SaveChangesAsync();
        }

        public virtual async Task Editar(CursoDto dto)
        {
            var curso = await _contexto.Cursos.FindAsync(dto.Id);
            curso.CargaHoraria = dto.CargaHoraria;
            curso.LimiteAlunos = dto.LimiteAlunos;
            curso.Nome = dto.Nome;
            curso.Valor = dto.Valor;
        }

        public virtual async Task Excluir(int id)
        {
            var curso = await _contexto.Cursos.FindAsync(id);
            _contexto.Cursos.Remove(curso);
        }

        public virtual async Task Incluir(CursoDto dto)
        {
            var curso = new Curso
            {
                CargaHoraria = dto.CargaHoraria,
                LimiteAlunos = dto.LimiteAlunos,
                Nome = dto.Nome,
                Valor = dto.Valor
            };
            _contexto.Cursos.Add(curso);
        }

        public virtual async Task<IEnumerable<CursoDto>> Listar()
        {
            var retorno = await (from c in _contexto.Cursos
                                 orderby c.Nome ascending
                                 select new CursoDto
                                 {
                                     CargaHoraria = c.CargaHoraria,
                                     Id = c.Id,
                                     LimiteAlunos = c.LimiteAlunos,
                                     Nome = c.Nome,
                                     Valor = c.Valor
                                 }).ToArrayAsync();

            return retorno;
        }

        public virtual async Task<CursoDto> ObterPorId(int id)
        {
            var retorno = await (from c in _contexto.Cursos
                                 where c.Id == id
                                 select new CursoDto
                                 {
                                     CargaHoraria = c.CargaHoraria,
                                     Id = c.Id,
                                     LimiteAlunos = c.LimiteAlunos,
                                     Nome = c.Nome,
                                     Valor = c.Valor
                                 }).FirstOrDefaultAsync();

            return retorno;
        }
    }
}
