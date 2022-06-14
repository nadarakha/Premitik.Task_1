namespace Premitik.Task_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "Color", c => c.String());
            AddColumn("dbo.Tasks", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Name");
            DropColumn("dbo.Status", "Color");
        }
    }
}
