namespace Treinamento.Domain.Dtos
{
    public class CursoDto
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual int CargaHoraria { get; set; }
        public virtual int LimiteAlunos { get; set; }
    }
}
