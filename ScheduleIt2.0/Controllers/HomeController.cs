using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleIt2._0.Models;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ScheduleIt2._0.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {

                //var email = model.FromEmail;
                var message = "<p><i>This is an automatic email system DO NOT REPLY.</i></p><p>Please reply to {0} at this link: {1}</p><p>Message: <br />{2}</p>";

                MailMessage msg = new MailMessage();

                msg.From = new MailAddress("scheduleitliveproject@gmail.com");
                msg.To.Add("seattledean@learncodinganywhere.com");
                //msg.To.Add("madelyn.haldeman@gmail.com");
                //msg.To.Add(model.FromEmail);
                msg.Subject = "[ScheduleIT]" + model.Subject;
                msg.Body = string.Format(message, model.FromName, model.FromEmail, model.MessageBody);
                msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential
                    ("scheduleitliveproject@gmail.com", "Techacademy1!");
                smtp.EnableSsl = true;


                smtp.Send(msg);


                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

    }
}