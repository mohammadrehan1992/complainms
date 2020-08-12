namespace ComplainMSModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Complains",
                c => new
                    {
                        ComplainId = c.Int(nullable: false, identity: true),
                        ComplainerId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Status = c.String(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ComplainId)
                .ForeignKey("dbo.Logins", t => t.ComplainerId, cascadeDelete: true)
                .Index(t => t.ComplainerId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        MacAddress = c.String(),
                        IPAddress = c.String(),
                        BrowserName = c.String(),
                        BrowserVerson = c.String(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.LoginId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complains", "ComplainerId", "dbo.Logins");
            DropIndex("dbo.Complains", new[] { "ComplainerId" });
            DropTable("dbo.Logins");
            DropTable("dbo.Complains");
        }
    }
}
