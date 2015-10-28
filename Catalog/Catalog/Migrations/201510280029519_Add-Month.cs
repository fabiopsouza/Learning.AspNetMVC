namespace Catalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMonth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthName = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Months");
        }
    }
}
