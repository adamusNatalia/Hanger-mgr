using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hanger.Models;

namespace Hanger.Controllers
{
    public class UserProfilController : Controller
    {
        private HangerDatabase db = new HangerDatabase();
        // GET: UserProfil
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NoItems()
        {
            return View();
        }
        public ActionResult UserCatalog(int id)
        {
            //User user = db.User.Find(id);
            //ViewBag.userId = id;
            //Ad advertisement = db.Ad.Find(Id);
            var ad = from s in db.Ad
                     where (s.UserId == id)
                     select s;
            User u = db.User.Find(id);
            ViewBag.profilName = u.Profil_name;
            if (ad.Count() == 0)
            {
                return RedirectToAction("NoItems", "UserProfil");
            }
            return View(ad.ToList());
            //return View(user);
        }

        public ActionResult Catalog(int id)
        {
            var ad = from s in db.Ad
                     where (s.UserId == id)
                     select s;
            if (ad.Count() == 0)
            {
                return RedirectToAction("NoItems", "UserProfil");
            }
            User u = db.User.Find(id);
            ViewBag.profilName = u.Profil_name;

            return View(ad.ToList());
        }

        public ActionResult UserProfil(int id)
        {
            //User user = db.User.Find(id);
            //ViewBag.userId = id;
            //Ad advertisement = db.Ad.Find(Id);
            var ad = from s in db.Ad
                     where (s.UserId == id)
                     select s;

            User u = db.User.Find(id);
            ViewBag.profilName = u.Profil_name;
            if (ad.Count() == 0)
            {
                return RedirectToAction("NoItems", "UserProfil");
            }
            return View(ad.ToList());

            //return View(user);
        }

        //[httppost]
        //public actionresult submitphoto()
        //{
        //    httppostedfilebase file = request.files[0];
        //    byte[] imagesize = new byte[file.contentlength];
        //    file.inputstream.read(imagesize, 0, (int)file.contentlength);


        //    using (hangerentities datacontext = new hangerentities())
        //    {
        //        photos p = new photos();
        //        p.adid = 1;
        //        p.name = file.filename;

        //        if (datacontext.photos != null && datacontext.photos.count() != 0)
        //        {
        //            p.id = (from ph in datacontext.photos
        //                    select ph.id).max() + 1;
        //        }
        //        else
        //            p.id = 0;


        //        p.type = file.contenttype;
        //        datacontext.photos.add(p);
        //        datacontext.savechanges();
        //    }

        //    return redirecttoaction("userwall", "wall");
        //}


    }
}