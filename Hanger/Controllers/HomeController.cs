using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hanger.Models;
using System.Net.Mail;
using System.Net;

namespace Hanger.Controllers
{
    public class HomeController : Controller
    {

        private HangerDatabase db = new HangerDatabase();
        public ActionResult Index()
        {
            var ad = from s in db.Ad
                     select s;

            return View(ad.ToList());

        }

        public ActionResult New()
        {
            
            ViewBag.Title = "Hanger";
            return View();
        }

        public ActionResult Interface()
        {

            ViewBag.Title = "Hanger";
            return View();
        }

        public ActionResult AboutUs()
        {

            ViewBag.Title = "Hanger";
            return View();
        }
        public ActionResult Contact()
        {

            ViewBag.Title = "Hanger";
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(string email, string body, string subject)
        {
            if (email != "" && subject != "" && body != "")
            {
                

                
                MailMessage msg = new MailMessage();

                //String emailTo = user.First().Mail;

                //msg.To.Add(emailTo);
                msg.To.Add("hanger.natalia@gmail.com");
                //msg.From = new MailAddress(email);
                msg.From = new MailAddress("hanger.natalia@gmail.com", email);
                //msg.Sender = new MailAddress(email);

                msg.Subject = subject;

                msg.Body = @body;
                msg.Priority = MailPriority.Normal;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.Credentials = new NetworkCredential("hanger.natalia@gmail.com", "hangertest");

                client.EnableSsl = true;

                client.Send(msg);

            }
            return RedirectToAction("Index", "Home");
        }

    }
}