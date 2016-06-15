namespace Treinamento.Domain.Migrations
{
    using Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Treinamento.Domain.Contexto.TreinamentoContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Treinamento.Domain.Contexto.TreinamentoContexto context)
        {
            context.Cursos.AddOrUpdate(c => c.Nome,
                new Curso { CargaHoraria = 20, LimiteAlunos = 20, Nome = "Informática Básica", Valor = 200 },
                new Curso { CargaHoraria = 30, LimiteAlunos = 30, Nome = "Danielês para iniciantes", Valor = 500 });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
