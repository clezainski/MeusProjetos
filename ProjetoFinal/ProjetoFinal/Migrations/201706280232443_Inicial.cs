namespace ProjetoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bibliotecas",
                c => new
                    {
                        BibliotecaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.BibliotecaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bibliotecas");
        }
    }
}
