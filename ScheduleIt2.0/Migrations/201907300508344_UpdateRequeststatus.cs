namespace ScheduleIt2._0.Migrations //adding migration for updating database for requeststatus column.
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRequeststatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventModels", "RequestStatus", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "RequestStatus", c => c.Boolean());
        }
    }
}
