namespace stock_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facture_Articles", "Name", c => c.String());
            AddColumn("dbo.Facture_Articles", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Facture_Articles", "payer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Facture_Articles", "email");
            DropColumn("dbo.Facture_Articles", "Unit_Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facture_Articles", "Unit_Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Facture_Articles", "email", c => c.String());
            DropColumn("dbo.Facture_Articles", "payer");
            DropColumn("dbo.Facture_Articles", "Price");
            DropColumn("dbo.Facture_Articles", "Name");
        }
    }
}
