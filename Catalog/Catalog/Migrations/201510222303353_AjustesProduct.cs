namespace Catalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustesProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Photo");
            DropColumn("dbo.Products", "PhotoType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PhotoType", c => c.String());
            AddColumn("dbo.Products", "Photo", c => c.Binary());
        }
    }
}
