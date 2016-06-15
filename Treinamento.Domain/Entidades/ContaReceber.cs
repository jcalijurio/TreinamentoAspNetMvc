namespace Treinamento.Domain.Entidades
{
    public class ContaReceber
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public bool Quitado { get; set; }
        public int MatriculaId { get; set; }

        public virtual Matricula Matricula { get; set; }
    }
}
