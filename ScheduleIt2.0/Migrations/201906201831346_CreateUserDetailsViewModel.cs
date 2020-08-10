namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserDetailsViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetailsViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        HourlyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDetailsViewModels");
        }
    }
}
