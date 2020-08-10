using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleIt2._0.Models
{

    public enum RequestStatus//creating enum here
    {
        Grant =0,
        Deny = 1,
        Pending =2
    }
    public class TimeOffEvent : EventModel
    {
        // Add the two properties needed that are not inherited from EventModel

        /// <summary>
        /// Date of Submission
        /// </summary>
        [Display(Name = "Time of Request")]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.DateTime)]        
        public DateTime Submitted { get; set; }

        /// <summary>
        /// Request Status
        /// </summary>
        [Display(Name = "Request Status")]
        public RequestStatus? RequestStatus { get; set; }

        //create parameterless constructor
        public TimeOffEvent()
        {

        }

    }
}