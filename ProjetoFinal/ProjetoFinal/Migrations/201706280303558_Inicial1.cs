namespace ProjetoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Literaturas",
                c => new
                    {
                        LiteraturaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LiteraturaID);
            
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        LivroID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40),
                        Autor = c.String(nullable: false, maxLength: 40),
                        Descricao = c.String(nullable: false, maxLength: 100),
                        LiteraturaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LivroID)
                .ForeignKey("dbo.Literaturas", t => t.LiteraturaID, cascadeDelete: true)
                .Index(t => t.LiteraturaID);
            
            AddColumn("dbo.AspNetUsers", "Idade", c => c.Int(nullable: false));
            DropTable("dbo.Bibliotecas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bibliotecas",
                c => new
                    {
                        BibliotecaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.BibliotecaID);
            
            DropForeignKey("dbo.Livroes", "LiteraturaID", "dbo.Literaturas");
            DropIndex("dbo.Livroes", new[] { "LiteraturaID" });
            DropColumn("dbo.AspNetUsers", "Idade");
            DropTable("dbo.Livroes");
            DropTable("dbo.Literaturas");
        }
    }
}
