namespace Treinamento.Domain.Entidades
{
    public class DebitoVencido
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int AlunoId { get; set; }

        public virtual Aluno Aluno { get; set; }
    }
}
