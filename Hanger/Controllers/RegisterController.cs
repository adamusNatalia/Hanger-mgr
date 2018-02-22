using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hanger.Models;
using System.Data.Entity.Infrastructure;

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
                    var user = (from p in db.User
                                select p);


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
                        Session["LogedUserID"] = (user.Count()-1);
                        //return RedirectToAction("AfterLogin", "Login");
                    }

                }
            }

            return RedirectToAction("AfterRegister", "Login" );
        }

        public ActionResult NewProfil()
        {

            SizeDropDownList();
            BrandDropDownList();
            ColorDropDownList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewProfil(Ad A)
        {
            //int adId=32;
            try
            {
                if (ModelState.IsValid)

                {
                    A.UserId = (Session["LogedUserID"] as User).Id;
                    //A.Id = 23;

                    db.Ad.Add(A);

                    //db.SaveChanges();
                    try
                    {
                        db.SaveChanges();

                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting
                                // the current instance as InnerException
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }
                    ModelState.Clear();

                }
                else
                {

                    SizeDropDownList(A.SizeId);
                    BrandDropDownList(A.BrandId);
                    ColorDropDownList(A.ColorId);



                    return View(A);
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }


            SizeDropDownList(A.SizeId);
            BrandDropDownList(A.BrandId);
            ColorDropDownList(A.ColorId);

            int adId = (from ad in db.Ad
                        select ad.Id).Max();

            //return View(A);
            return RedirectToAction("Photo1", "Ad", new { id = adId });

        }



        private void SizeDropDownList(object selectedSize = null)
        {
            var sizeQuery = from d in db.Size
                            orderby d.Id
                            select d;
            ViewBag.SizeId = new SelectList(sizeQuery, "Id", "Name", selectedSize);
        }
        private void ColorDropDownList(object selectedColor = null)
        {
            var sizeQuery = from d in db.Color
                            orderby d.Name
                            select d;
            ViewBag.COlorId = new SelectList(sizeQuery, "Id", "Name", selectedColor);
        }
        private void BrandDropDownList(object selectedBrand = null)
        {
            var sizeQuery = from d in db.Brand
                            orderby d.Id
                            select d;
            ViewBag.BrandId = new SelectList(sizeQuery, "Id", "Name", selectedBrand);
        }


    }
}