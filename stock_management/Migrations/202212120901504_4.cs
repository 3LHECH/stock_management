namespace stock_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "quantite", c => c.Int(nullable: false));
            AddColumn("dbo.Facture_Articles", "quantite", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facture_Articles", "quantite");
            DropColumn("dbo.Articles", "quantite");
        }
    }
}
