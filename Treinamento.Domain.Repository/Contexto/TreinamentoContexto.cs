using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Treinamento.Domain.Entidades;
using Treinamento.Domain.Repository.Mapping;

namespace Treinamento.Domain.Repository.Contexto
{
    public class TreinamentoContexto : DbContext
    {
        public TreinamentoContexto() : this("TreinamentoConnection")
        { }

        public TreinamentoContexto(string connection)
            : base(connection)
        {
            Database.Log = m => Debug.WriteLine(m);
        }

        public DbSet<Convenio> Convenios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<ContaReceber> ContasReceber { get; set; }
        public DbSet<DebitoVencido> DebitosVencidos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ConvenioMap());
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new CursoMap());
            modelBuilder.Configurations.Add(new ContaReceberMap());
            modelBuilder.Configurations.Add(new DebitoVencidoMap());
            modelBuilder.Configurations.Add(new MatriculaMap());
            modelBuilder.Configurations.Add(new TurmaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
