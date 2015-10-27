namespace Catalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertLastCommit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Photo");
        }
    }
}
