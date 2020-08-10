using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleIt2._0.Models
{


    public class UserViewModel
    {
        //create view model for user details

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dob { get; set; }

        public string Address { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Hourly Pay")]
        public decimal HourlyRate { get; set; }

        [Display(Name = "Date of Hire")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [Display(Name = "Date of Termination")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }


        //bind data from ApplicationUser model
        public UserViewModel(ApplicationUser u)
        {
            Id = u.Id;
            Fname = u.Fname;
            Lname = u.Lname;
            Dob = u.BirthDate;
            Address = u.Address;
            Email = u.Email;
            HourlyRate = u.HourlyRate;
            Start = u.StartDate;
            End = u.EndDate;

        }

        //create an empty constructor
        public UserViewModel()
        {

        }
    }

    
}