namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubjectToEmailModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailModels", "Subject", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailModels", "Subject");
        }
    }
}
