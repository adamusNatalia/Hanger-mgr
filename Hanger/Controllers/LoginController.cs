using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hanger.Models;
namespace Hanger.Controllers
{
    public class LoginController : Controller
    {
        private HangerDatabase db = new HangerDatabase();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var users = from s in db.User
                           select s;

            return View(users.ToList());
        }


        public ActionResult Login()
        {
            if (Session["LogedUserID"] == null)
                Session.Add("LogedUserID", null);
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {

            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("Photo");
            ModelState.Remove("Description");
            ModelState.Remove("Mail");
            ModelState.Remove("Date_access");

            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
               
                {
                    Console.WriteLine("Zalogowano");
                    //var v = db.User.Where(a => a.Profil_name.Equals(u.Profil_name) && a.Password.Equals(u.Password)).FirstOrDefault();
                    var user = from p in db.User
                               where p.Profil_name == u.Profil_name && p.Password == u.Password
                               select p;


                    //if (v != null)
                    //{
                    //    //Session["LogedUserID"] = v.Id.ToString();
                    //    Session["CurrentUserEmail"] = v.First();
                    //    Session["LogedUserFullname"] = v.Profil_name.ToString();
                    //    if (v.Profil_name.ToString() == "admin")
                    //    {
                    //        return RedirectToAction("AfterLoginAdmin");
                    //    }
                    //    return RedirectToAction("AfterLogin");
                    //}

                    if (user.Count() != 0)
                    {
                        Session["LogedUserID"] = user.First();
                        return RedirectToAction("AfterLogin");
                    }
                   

                }
            }
            // return RedirectToAction("UserProfil", "UserProfil", new { id = (Session["LogedUserID"] as Hanger.Models.User).Id });
            ModelState.AddModelError("", "Błędna nazwa profilu lub hasło. Proszę wprowadź prawidłowe dane.");
            return View(u);
        }

        public ActionResult AfterRegister()
        {
            if (Session["LogedUserID"] == null)
                Session.Add("LogedUserID", null);
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AfterRegister(User u)
        {

            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("Photo");
            ModelState.Remove("Description");
            ModelState.Remove("Mail");
            ModelState.Remove("Date_access");

            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {

                {
                    Console.WriteLine("Zalogowano");
                    //var v = db.User.Where(a => a.Profil_name.Equals(u.Profil_name) && a.Password.Equals(u.Password)).FirstOrDefault();
                    var user = from p in db.User
                               where p.Profil_name == u.Profil_name && p.Password == u.Password
                               select p;


                    //if (v != null)
                    //{
                    //    //Session["LogedUserID"] = v.Id.ToString();
                    //    Session["CurrentUserEmail"] = v.First();
                    //    Session["LogedUserFullname"] = v.Profil_name.ToString();
                    //    if (v.Profil_name.ToString() == "admin")
                    //    {
                    //        return RedirectToAction("AfterLoginAdmin");
                    //    }
                    //    return RedirectToAction("AfterLogin");
                    //}

                    if (user.Count() != 0)
                    {
                        Session["LogedUserID"] = user.First();
                        return RedirectToAction("AfterLogin");
                    }


                }
            }
            // return RedirectToAction("UserProfil", "UserProfil", new { id = (Session["LogedUserID"] as Hanger.Models.User).Id });
            ModelState.AddModelError("", "Błędna nazwa profilu lub hasło. Proszę wprowadź prawidłowe dane.");
            return View(u);
        }
        public ActionResult LogOut()
        {
            Session["LogedUserID"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return RedirectToAction("UserProfil", "UserProfil", new { id = (Session["LogedUserID"] as Hanger.Models.User).Id });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}