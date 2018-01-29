using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hanger.Models;

namespace Hanger.Controllers
{
    public class RegisterController : Controller
    {
        private HangerDatabase db = new HangerDatabase();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult IsProfilNameAvailable(string Profil_name)
        {
            return Json(!db.User.Any(user => user.Profil_name == Profil_name),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IsMailAvailable(string Mail)
        {
            return Json(!db.User.Any(user => user.Mail == Mail), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User U)
        {
            if (ModelState.IsValid)
            {
              
                {
                    U.Date_access = DateTime.Now;
                    db.User.Add(U);
                    db.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Successfully Registration Done";
                }
            }
            return RedirectToAction("AfterRegister", "Login" );
        }

    }
}