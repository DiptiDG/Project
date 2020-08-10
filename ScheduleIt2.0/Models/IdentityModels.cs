using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ScheduleIt2._0.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Fname", Fname));  //claims to call first and last names added
            userIdentity.AddClaim(new Claim("Lname", Lname));

            return userIdentity;
        }


        // Add data annotations for display names and date formats


        [Display(Name = "First Name"), Required]
        public string Fname { get; set; }

        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string Address { get; set; }
        
        public bool FullTime { get; set; }

        [Display(Name = "Date of Hire")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date of Termination")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Hourly Pay")]
        public decimal HourlyRate { get; set; }

        public string Status { get; set; }

		// add DbImage class to identity model
		public virtual DbImage Image { get; set; }


	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ScheduleIt2._0.Migrations.Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<EventModel> EventModels { get; set; }
        public DbSet<WorkTimeEventModel> WorkTimeEventModels { get; set; }
        public DbSet<TimeOffEvent> TimeOffEvents { get; set; }
        public DbSet<MessageSystem> MessageSystems { get; set; }
        public DbSet<EmailModel> EmailModels { get; set; }

        // create DbSet for UserDetailsViewModels
        public DbSet<UserDetailsViewModel> UserDetailsViewModels { get; set; }

		// create DbSet for DbImage
		public DbSet<DbImage> DbImages { get; set; }

        public DbSet<ScheduleEvent> scheduleEvents { get; set; }

		///public System.Data.Entity.DbSet<ScheduleIt2._0.Models.UserDetailsViewModel> UserDetailsViewModels { get; set; }
		/// public System.Data.Entity.DbSet<ScheduleIt2._0.Models.TimeOffEvent> TimeOffEvents { get; set; }
	}
}