using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Hanger.Models;

namespace Hanger.Controllers
{
    public class MailController : Controller
    {
        private HangerDatabase db = new HangerDatabase();
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmailRequest()
        {
            return View();
        }
        public ActionResult ProcessRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail()
        {
            // MailMessage msg = new MailMessage();
            // msg.To.Add("hanger.natalia@gmail.com");
            // msg.From = new MailAddress("hanger.natalia@gmail.com");
            MailMessage msg = new MailMessage("hanger.natalia@gmail.com", "fraszkaa@interia.pl");
            msg.Subject = "Welcome To REBAR Mobile Showcase";
            msg.Body = "Hi," + Environment.NewLine + @"Welcome to REBAR Mobile Showcase. Please click on the below link : https://ciouishowcase.accenture.com/mobile/m"
                + Environment.NewLine + "Regards," + Environment.NewLine + "CIO Design Agency";
            msg.Priority = MailPriority.Normal;

            SmtpClient client = new SmtpClient("smtp.gmail.com",587);

            client.Credentials = new NetworkCredential("hanger.natalia@gmail.com", "hangertest");
           // client.Host = "email.abc.com";
           //client.Port = 587;
          //  client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
           // client.UseDefaultCredentials = true;
            client.Send(msg);
            return RedirectToAction("Index", "Mail");
        }


    }
}