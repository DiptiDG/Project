namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmailModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailModels", "FromName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailModels", "FromName");
        }
    }
}
