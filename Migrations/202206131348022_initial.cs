namespace Premitik.Task_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        CaseNumber = c.Int(nullable: false),
                        Source = c.String(),
                        CustomerName = c.String(),
                        Email = c.String(),
                        MobilePhone = c.String(),
                        ReleaseNumber = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "StatusId", "dbo.Status");
            DropIndex("dbo.Tasks", new[] { "StatusId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Status");
        }
    }
}
