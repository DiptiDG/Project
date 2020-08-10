namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdentityModelWithDbImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbImages",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        DbImageId = c.Guid(nullable: false),
                        Photo = c.Binary(),
                        ContentType = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbImages", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.DbImages", new[] { "UserId" });
            DropTable("dbo.DbImages");
        }
    }
}
