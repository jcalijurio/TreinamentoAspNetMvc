namespace Treinamento.Domain.Dtos
{
    public class MatriculaDto
    {
        public virtual int Id { get; set; }
        public virtual int AlunoId { get; set; }
        public virtual int TurmaId { get; set; }
        public virtual string Aluno { get; set; }
        public virtual int Turma { get; set; }
        public virtual string Curso { get; set; }
        public virtual int CursoId { get; set; }
    }
}
