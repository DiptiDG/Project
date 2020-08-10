using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleIt2._0.Models
{
	// create model for user image
	public class DbImage
	{
		public Guid DbImageId { get; set; }

		public byte[] Photo { get; set; }
		public string ContentType { get; set; }

		[Key, ForeignKey("User")]
		public string UserId { get; set; }

		public virtual ApplicationUser User { get; set; }
	}
}