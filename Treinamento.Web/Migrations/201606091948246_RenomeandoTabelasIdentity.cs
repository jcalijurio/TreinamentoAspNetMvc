namespace Treinamento.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenomeandoTabelasIdentity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "Papeis");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UsuarioPapel");
            RenameTable(name: "dbo.AspNetUsers", newName: "Usuarios");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "Claims");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "Logins");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Logins", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.Claims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.Usuarios", newName: "AspNetUsers");
            RenameTable(name: "dbo.UsuarioPapel", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.Papeis", newName: "AspNetRoles");
        }
    }
}
