namespace Treinamento.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InclusaoSexoBiru : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Sexo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "Sexo");
        }
    }
}
