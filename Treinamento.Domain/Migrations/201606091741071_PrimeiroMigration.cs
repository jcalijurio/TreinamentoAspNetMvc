namespace Treinamento.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiroMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Cpf = c.String(maxLength: 14),
                        DtNascimento = c.DateTime(nullable: false),
                        ConvenioId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Convenio", t => t.ConvenioId)
                .Index(t => t.ConvenioId);
            
            CreateTable(
                "dbo.Convenio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Desconto = c.Decimal(nullable: false, precision: 5, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DebitoVencido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 10, scale: 2),
                        AlunoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aluno", t => t.AlunoId)
                .Index(t => t.AlunoId);
            
            CreateTable(
                "dbo.Matricula",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        TurmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aluno", t => t.AlunoId)
                .ForeignKey("dbo.Turma", t => t.TurmaId)
                .Index(t => t.AlunoId)
                .Index(t => t.TurmaId);
            
            CreateTable(
                "dbo.ContaReceber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Quitado = c.Boolean(nullable: false),
                        MatriculaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matricula", t => t.MatriculaId)
                .Index(t => t.MatriculaId);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        DtInicio = c.DateTime(nullable: false),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Curso", t => t.CursoId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        CargaHoraria = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LimiteAlunos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matricula", "TurmaId", "dbo.Turma");
            DropForeignKey("dbo.Turma", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.ContaReceber", "MatriculaId", "dbo.Matricula");
            DropForeignKey("dbo.Matricula", "AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.DebitoVencido", "AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.Aluno", "ConvenioId", "dbo.Convenio");
            DropIndex("dbo.Turma", new[] { "CursoId" });
            DropIndex("dbo.ContaReceber", new[] { "MatriculaId" });
            DropIndex("dbo.Matricula", new[] { "TurmaId" });
            DropIndex("dbo.Matricula", new[] { "AlunoId" });
            DropIndex("dbo.DebitoVencido", new[] { "AlunoId" });
            DropIndex("dbo.Aluno", new[] { "ConvenioId" });
            DropTable("dbo.Curso");
            DropTable("dbo.Turma");
            DropTable("dbo.ContaReceber");
            DropTable("dbo.Matricula");
            DropTable("dbo.DebitoVencido");
            DropTable("dbo.Convenio");
            DropTable("dbo.Aluno");
        }
    }
}
