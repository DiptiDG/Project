using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ScheduleIt2._0.Models
{
    public class UserDetailsViewModel
    {
        // create view model for user details

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Hourly Pay")]
        public decimal HourlyRate { get; set; }

        [Display(Name = "Date of Hire")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date of Termination")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

		// add user image to view model
		public DbImage Image { get; set; }



		// bind data from ApplicationUser model
		public UserDetailsViewModel(ApplicationUser u)
        {
            Id = u.Id;
            Fname = u.Fname;
            Lname = u.Lname;
            BirthDate = u.BirthDate;
            Address = u.Address;
            Email = u.Email;
            HourlyRate = u.HourlyRate;
            StartDate = u.StartDate;
            EndDate = u.EndDate;
			// pass ApplicationUser image 
			// as image in view model
			Image = u.Image;
        }

        //create an empty constructor
        public UserDetailsViewModel()
        {

        }
    }
}