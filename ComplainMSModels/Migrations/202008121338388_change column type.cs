namespace ComplainMSModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecolumntype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Complains", "ComplainerId", "dbo.Logins");
            DropIndex("dbo.Complains", new[] { "ComplainerId" });
            AlterColumn("dbo.Complains", "ComplainerId", c => c.Int());
            CreateIndex("dbo.Complains", "ComplainerId");
            AddForeignKey("dbo.Complains", "ComplainerId", "dbo.Logins", "LoginId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complains", "ComplainerId", "dbo.Logins");
            DropIndex("dbo.Complains", new[] { "ComplainerId" });
            AlterColumn("dbo.Complains", "ComplainerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Complains", "ComplainerId");
            AddForeignKey("dbo.Complains", "ComplainerId", "dbo.Logins", "LoginId", cascadeDelete: true);
        }
    }
}
