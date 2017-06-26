namespace SistemaControleVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Usuarios", name: "_Perfil_PerfilID", newName: "PerfilID");
            RenameIndex(table: "dbo.Usuarios", name: "IX__Perfil_PerfilID", newName: "IX_PerfilID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Usuarios", name: "IX_PerfilID", newName: "IX__Perfil_PerfilID");
            RenameColumn(table: "dbo.Usuarios", name: "PerfilID", newName: "_Perfil_PerfilID");
        }
    }
}
