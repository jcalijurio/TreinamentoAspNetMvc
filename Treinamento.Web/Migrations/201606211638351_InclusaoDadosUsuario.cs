namespace Treinamento.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InclusaoDadosUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Nome", c => c.String());
            AddColumn("dbo.Usuarios", "Idade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Idade");
            DropColumn("dbo.Usuarios", "Nome");
        }
    }
}
