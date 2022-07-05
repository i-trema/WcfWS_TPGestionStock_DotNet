namespace WcfWS_TPGestionStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiale1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "QteMini", c => c.Int());
            AlterColumn("dbo.Articles", "Prix", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Prix", c => c.Double(nullable: false));
            AlterColumn("dbo.Articles", "QteMini", c => c.Int(nullable: false));
        }
    }
}
