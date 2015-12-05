namespace Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeClient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Client", new[] { "Id" });
            DropTable("dbo.Client");
        }
    }
}
