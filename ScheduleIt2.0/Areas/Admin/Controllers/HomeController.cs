using ScheduleIt2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ScheduleIt2._0.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
		
		// item.id from the userdetails partial is being passed in as a parameter
		[HttpGet]
		public PartialViewResult LoadPartialView(string id)
		{
			//gets the user details from the ApplicationUser model
			//where the id matches the id passed in as a parameter
			var user = db.Users.Where(x => x.Id == id).First();

			//create a new instance of the UserDetailsViewModel and pass in 
			//the user data to populate the table in the _ViewUserDetails model
			UserDetailsViewModel userDetails = new UserDetailsViewModel(user);

			//return the partial view and pass in new model data
			return PartialView("_ViewUserDetails", userDetails);
		}

		// load the partial view in the ViewUserDetails partial
		public ActionResult UserImage()
		{
			return View();
		}

		// id from from partial is being passed in as a parameter as is userImage
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddUserImage(string id, HttpPostedFileBase userImage)
		{
			var userToUpdate = db.Users.Find(id);

			if (userImage != null && userImage.ContentLength > 0)
			{
				if (userToUpdate.Image != null)
				{
					db.DbImages.Remove(userToUpdate.Image);
				}

				var avatar = new DbImage()
				{
					DbImageId = Guid.NewGuid(),
					ContentType = userImage.ContentType,
				};

				using (var reader = new System.IO.BinaryReader(userImage.InputStream))
				{
					avatar.Photo = reader.ReadBytes(userImage.ContentLength);
				}

				avatar.UserId = id;

				db.DbImages.Add(avatar);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public ActionResult RetrieveUserImage(string id)
		{
			var f = db.Users.Find(id);
			if (f != null)
			{
				if (f.Image != null)
				{
					return File(f.Image.Photo, f.Image.ContentType);
				}

			}
			return View();
		}
	}
}