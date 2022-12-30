namespace stock_management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "quantite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "quantite", c => c.String());
        }
    }
}
