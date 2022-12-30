namespace stock_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Facture_Articles", "quantite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facture_Articles", "quantite", c => c.String());
        }
    }
}
