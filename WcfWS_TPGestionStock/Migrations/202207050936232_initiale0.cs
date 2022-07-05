namespace WcfWS_TPGestionStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiale0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        QteMini = c.Int(nullable: false),
                        Prix = c.Double(nullable: false),
                        Categorie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categorie_Id)
                .Index(t => t.Categorie_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Categorie_Id", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "Categorie_Id" });
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
        }
    }
}
