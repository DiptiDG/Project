namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserDetailsViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetailsViewModels", "Image_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserDetailsViewModels", "Image_UserId");
            AddForeignKey("dbo.UserDetailsViewModels", "Image_UserId", "dbo.DbImages", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDetailsViewModels", "Image_UserId", "dbo.DbImages");
            DropIndex("dbo.UserDetailsViewModels", new[] { "Image_UserId" });
            DropColumn("dbo.UserDetailsViewModels", "Image_UserId");
        }
    }
}
