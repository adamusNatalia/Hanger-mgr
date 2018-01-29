using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hanger.Models;
using PagedList;
using PagedList.Mvc;

namespace Hanger.Controllers
{
    public class CatalogController : Controller
    {
        private HangerDatabase db = new HangerDatabase();


        public ActionResult Index1(int id, string sortOrder, string searchBy, string search, int? page, string size)
        {
            var ad = from s in db.Ad
                     where (s.SubcategoryId == id)
                     select s;
            if (ad == null)
            {
                return RedirectToAction("NoItems", "Catalog");
            }

            var SizeLst = new List<string>();

            var SizeQry2 = from d in db.Ad
                           orderby d.SizeId
                           select d.SizeId;

            var SizeQry = from d in db.Size
                          orderby d.Name
                          select d.Name;
            //var SizeQry= from 

            SizeLst.AddRange(SizeQry.Distinct());
            ViewBag.size = new SelectList(SizeLst);

            var IdSize= from d in db.Size
                        where (d.Name==size)
                        select d.Id;
            //Size sId = new Size();
            //sId = (from d in db.Size
            //       where (d.Name == size)
            //       select d).Max();
            //int idSize = (from d in db.Size
            //       where (d.Name == size)
            //       select d.Id).Max();
            //int formID = int.Parse(IdSize.First());

            if (!String.IsNullOrEmpty(size))
            {
                int idSize = (from d in db.Size
                       where (d.Name == size)
                       select d.Id).Max();
                //ad = ad.Where(x => x.SizeId == idSize);
                ad = ad.Where(x => x.SizeId == 4);
                int amount=ad.Count();
                int amount2 = ad.Count();
            }


            //if (searchBy == "Color")
            //{
            //    return View(db.Ad.Where(x => x.ColorId.Equals(Int32.Parse(search)) || search == null).ToList().ToPagedList(page ?? 1, 5));
            //}
            //else
            //    if (searchBy == "Size")
            //{
            //    return View(db.Ad.Where(x => x.SizeId.Equals(Int32.Parse(search)) || search == null).ToList().ToPagedList(page ?? 1, 5));
            //}


            ViewBag.ThemeSortParm = sortOrder == "Price" ? "price_desc" : "Price";
           // ViewBag.LpSortParm = String.IsNullOrEmpty(sortOrder) ? "lp_desc" : "";
          //  ViewBag.StatusSortParm = sortOrder == "Status" ? "status_desc" : "Status";



            switch (sortOrder)
            {
                case "price_desc":
                    ad = ad.OrderByDescending(a => a.Price);
                    break;
                case "Price":
                    ad = ad.OrderBy(a => a.Price);
                    break;
                //case "lp_desc":
                //    ad = ad.OrderByDescending(s => s.ID);
                //    break;

                //case "Status":
                //    ad = ad.OrderBy(s => s.Status);
                //    break;
                //case "status_desc":
                //    ad = ad.OrderByDescending(s => s.Status);
                //    break;
                default:
                    ad = ad.OrderBy(s => s.Id);
                    break;
            }

            
            return View(ad.ToList().ToPagedList(page ?? 1, 9));
        }

        public ActionResult Index(int id, string size, string brand, string condition, string color,string price1, string price2, int? page)
        {

            var ad = from s in db.Ad
                    where (s.SubcategoryId == id)
                     select s;

            var sub= from s in db.Subcategory
                     where (s.Id == id)
                     select s.Name;
        
            ViewBag.subcategory = sub.FirstOrDefault();

            //ViewBag.subcategory = ad.FirstOrDefault().Subcategory.Name;
            

            var SizeLst = new List<string>();

            var SizeQry = from d in db.Size
                          orderby d.Name
                          select d.Name;

            SizeLst.AddRange(SizeQry.Distinct());
            ViewBag.size = new SelectList(SizeLst);

            var IdSize = from d in db.Size
                         where (d.Name == size)
                         select d.Id;

            var BrandLst = new List<string>();

            var BrandQry = from d in db.Brand
                          orderby d.Name
                          select d.Name;

            BrandLst.AddRange(BrandQry.Distinct());
            ViewBag.brand = new SelectList(BrandLst);

            var IdBrand = from d in db.Brand
                         where (d.Name == brand)
                         select d.Id;
            var ConditionLst = new List<string>();

            var ConditionQry = from d in db.Condition
                           orderby d.Name
                           select d.Name;

            ConditionLst.AddRange(ConditionQry.Distinct());
            ViewBag.condition = new SelectList(ConditionLst);

            var IdCondition = from d in db.Condition
                          where (d.Name == condition)
                          select d.Id;

            var ColorLst = new List<string>();

            var ColorQry = from d in db.Color
                           orderby d.Name
                           select d.Name;

            ColorLst.AddRange(ColorQry.Distinct());
            ViewBag.color = new SelectList(ColorLst);

            var IdColor = from d in db.Brand
                          where (d.Name == color)
                          select d.Id;

            //var PriceFromLst = new List<string>();

            //var PriceFromQry = from d in db.Ad
            //               orderby d.Price
            //               select d.Price;

            //PriceFromLst.AddRange(PriceFromQry.Distinct());
            //ViewBag.color = new SelectList(ColorLst);

            //var IdColor = from d in db.Brand
            //              where (d.Name == color)
            //              select d.Id;
            List<SelectListItem> Price = new List<SelectListItem>();
            Price.Add(new SelectListItem() { Text = "10 zł", Value = "10" });
            Price.Add(new SelectListItem() { Text = "20 zł", Value = "20" });
            Price.Add(new SelectListItem() { Text = "30 zł", Value = "30" });
            Price.Add(new SelectListItem() { Text = "40 zł", Value = "40" });
            Price.Add(new SelectListItem() { Text = "50 zł", Value = "50" });
            Price.Add(new SelectListItem() { Text = "60 zł", Value = "60" });
            Price.Add(new SelectListItem() { Text = "70 zł", Value = "70" });
            Price.Add(new SelectListItem() { Text = "80 zł", Value = "80" });
            Price.Add(new SelectListItem() { Text = "90 zł", Value = "90" });
            Price.Add(new SelectListItem() { Text = "100 zł", Value = "100" });
            Price.Add(new SelectListItem() { Text = "110 zł", Value = "110" });
            Price.Add(new SelectListItem() { Text = "120 zł", Value = "120" });
            Price.Add(new SelectListItem() { Text = "130 zł", Value = "130" });
            Price.Add(new SelectListItem() { Text = "140 zł", Value = "140" });
            Price.Add(new SelectListItem() { Text = "150 zł", Value = "150" });
            Price.Add(new SelectListItem() { Text = "200 zł", Value = "200" });

            ViewBag.price1 = new SelectList(Price, "Value", "Text");
            ViewBag.price2 = new SelectList(Price, "Value", "Text");


            if (!String.IsNullOrEmpty(size))
            {
                int idSize = (from d in db.Size
                              where (d.Name == size)
                              select d.Id).Max();
                ad = ad.Where(x => x.SizeId == idSize);
            }
            if (!String.IsNullOrEmpty(condition))
            {
                int idCondition = (from d in db.Condition
                              where (d.Name == condition)
                              select d.Id).Max();
                ad = ad.Where(x => x.ConditionId == idCondition);
            }

            if (!String.IsNullOrEmpty(color))
            {
                int idColor = (from d in db.Color
                              where (d.Name == color)
                              select d.Id).Max();
                ad = ad.Where(x => x.ColorId == idColor);    
            }

            if (!String.IsNullOrEmpty(brand))
            {
                int idBrand = (from d in db.Brand
                               where (d.Name == brand)
                               select d.Id).Max();
                ad = ad.Where(x => x.BrandId == idBrand);

            }

            if (!String.IsNullOrEmpty(price1))
            {
                float from = float.Parse(price1);
                ad = ad.Where(x => x.Price>=from);

            }
            if (!String.IsNullOrEmpty(price2))
            {
                float to = float.Parse(price2);
                ad = ad.Where(x => x.Price <= to);

            }

            ad = ad.OrderByDescending(s => s.Id);
            return View(ad.ToList().ToPagedList(page ?? 1, 32));
        }

        public ActionResult New(string size, string brand, string condition, string color, string price1, string price2, int? page)
        {

            var ad = from s in db.Ad
                     select s;
            if (ad == null)
            {
                return RedirectToAction("NoItems", "Catalog");
            }

            var SizeLst = new List<string>();

            var SizeQry = from d in db.Size
                          orderby d.Name
                          select d.Name;

            SizeLst.AddRange(SizeQry.Distinct());
            ViewBag.size = new SelectList(SizeLst);

            var IdSize = from d in db.Size
                         where (d.Name == size)
                         select d.Id;

            var BrandLst = new List<string>();

            var BrandQry = from d in db.Brand
                           orderby d.Name
                           select d.Name;

            BrandLst.AddRange(BrandQry.Distinct());
            ViewBag.brand = new SelectList(BrandLst);

            var IdBrand = from d in db.Brand
                          where (d.Name == brand)
                          select d.Id;
            var ConditionLst = new List<string>();

            var ConditionQry = from d in db.Condition
                               orderby d.Name
                               select d.Name;

            ConditionLst.AddRange(ConditionQry.Distinct());
            ViewBag.condition = new SelectList(ConditionLst);

            var IdCondition = from d in db.Condition
                              where (d.Name == condition)
                              select d.Id;

            var ColorLst = new List<string>();

            var ColorQry = from d in db.Color
                           orderby d.Name
                           select d.Name;

            ColorLst.AddRange(ColorQry.Distinct());
            ViewBag.color = new SelectList(ColorLst);

            var IdColor = from d in db.Brand
                          where (d.Name == color)
                          select d.Id;


            List<SelectListItem> Price = new List<SelectListItem>();
            Price.Add(new SelectListItem() { Text = "10 zł", Value = "10" });
            Price.Add(new SelectListItem() { Text = "20 zł", Value = "20" });
            Price.Add(new SelectListItem() { Text = "30 zł", Value = "30" });
            Price.Add(new SelectListItem() { Text = "40 zł", Value = "40" });
            Price.Add(new SelectListItem() { Text = "50 zł", Value = "50" });
            Price.Add(new SelectListItem() { Text = "60 zł", Value = "60" });
            Price.Add(new SelectListItem() { Text = "70 zł", Value = "70" });
            Price.Add(new SelectListItem() { Text = "80 zł", Value = "80" });
            Price.Add(new SelectListItem() { Text = "90 zł", Value = "90" });
            Price.Add(new SelectListItem() { Text = "100 zł", Value = "100" });
            Price.Add(new SelectListItem() { Text = "110 zł", Value = "110" });
            Price.Add(new SelectListItem() { Text = "120 zł", Value = "120" });
            Price.Add(new SelectListItem() { Text = "130 zł", Value = "130" });
            Price.Add(new SelectListItem() { Text = "140 zł", Value = "140" });
            Price.Add(new SelectListItem() { Text = "150 zł", Value = "150" });
            Price.Add(new SelectListItem() { Text = "200 zł", Value = "200" });

            ViewBag.price1 = new SelectList(Price, "Value", "Text");
            ViewBag.price2 = new SelectList(Price, "Value", "Text");


            if (!String.IsNullOrEmpty(size))
            {
                int idSize = (from d in db.Size
                              where (d.Name == size)
                              select d.Id).Max();
                ad = ad.Where(x => x.SizeId == idSize);
            }
            if (!String.IsNullOrEmpty(condition))
            {
                int idCondition = (from d in db.Condition
                                   where (d.Name == condition)
                                   select d.Id).Max();
                ad = ad.Where(x => x.ConditionId == idCondition);
            }

            if (!String.IsNullOrEmpty(color))
            {
                int idColor = (from d in db.Color
                               where (d.Name == color)
                               select d.Id).Max();
                ad = ad.Where(x => x.ColorId == idColor);
            }

            if (!String.IsNullOrEmpty(brand))
            {
                int idBrand = (from d in db.Brand
                               where (d.Name == brand)
                               select d.Id).Max();
                ad = ad.Where(x => x.BrandId == idBrand);

            }

            if (!String.IsNullOrEmpty(price1))
            {
                float from = float.Parse(price1);
                ad = ad.Where(x => x.Price >= from);

            }
            if (!String.IsNullOrEmpty(price2))
            {
                float to = float.Parse(price2);
                ad = ad.Where(x => x.Price <= to);

            }
            ad = ad.OrderByDescending(s => s.Id);
            return View(ad.ToList().ToPagedList(page ?? 1, 32));
        }



        //[HttpPost]
        //public ActionResult Index(int id, string size, string brand, string condition, string color, int from, int to)
        //{



        //    var ad = from s in db.Ad
        //             where (s.SubcategoryId == id)
        //             select s;
        //    if (ad == null)
        //    {
        //        return RedirectToAction("NoItems", "Catalog");
        //    }

        //    var SizeLst = new List<string>();

        //    var SizeQry = from d in db.Size
        //                  orderby d.Name
        //                  select d.Name;

        //    SizeLst.AddRange(SizeQry.Distinct());
        //    ViewBag.size = new SelectList(SizeLst);

        //    var IdSize = from d in db.Size
        //                 where (d.Name == size)
        //                 select d.Id;

        //    var BrandLst = new List<string>();

        //    var BrandQry = from d in db.Brand
        //                   orderby d.Name
        //                   select d.Name;

        //    BrandLst.AddRange(BrandQry.Distinct());
        //    ViewBag.brand = new SelectList(BrandLst);

        //    var IdBrand = from d in db.Brand
        //                  where (d.Name == brand)
        //                  select d.Id;
        //    var ConditionLst = new List<string>();

        //    var ConditionQry = from d in db.Condition
        //                       orderby d.Name
        //                       select d.Name;

        //    ConditionLst.AddRange(ConditionQry.Distinct());
        //    ViewBag.condition = new SelectList(ConditionLst);

        //    var IdCondition = from d in db.Condition
        //                      where (d.Name == condition)
        //                      select d.Id;

        //    var ColorLst = new List<string>();

        //    var ColorQry = from d in db.Color
        //                   orderby d.Name
        //                   select d.Name;

        //    ColorLst.AddRange(ColorQry.Distinct());
        //    ViewBag.color = new SelectList(ColorLst);

        //    var IdColor = from d in db.Brand
        //                  where (d.Name == color)
        //                  select d.Id;

        //    //var PriceFromLst = new List<string>();

        //    //var PriceFromQry = from d in db.Ad
        //    //               orderby d.Price
        //    //               select d.Price;

        //    //PriceFromLst.AddRange(PriceFromQry.Distinct());
        //    //ViewBag.color = new SelectList(ColorLst);

        //    //var IdColor = from d in db.Brand
        //    //              where (d.Name == color)
        //    //              select d.Id;

        //    if (!String.IsNullOrEmpty(size))
        //    {
        //        int idSize = (from d in db.Size
        //                      where (d.Name == size)
        //                      select d.Id).Max();
        //        ad = ad.Where(x => x.SizeId == idSize);
        //    }
        //    if (!String.IsNullOrEmpty(condition))
        //    {
        //        int idCondition = (from d in db.Condition
        //                           where (d.Name == condition)
        //                           select d.Id).Max();
        //        ad = ad.Where(x => x.ConditionId == idCondition);
        //    }

        //    if (!String.IsNullOrEmpty(color))
        //    {
        //        int idColor = (from d in db.Color
        //                       where (d.Name == color)
        //                       select d.Id).Max();
        //        ad = ad.Where(x => x.ColorId == idColor);
        //    }

        //    if (!String.IsNullOrEmpty(brand))
        //    {
        //        int idBrand = (from d in db.Brand
        //                       where (d.Name == brand)
        //                       select d.Id).Max();
        //        ad = ad.Where(x => x.BrandId == idBrand);

        //    }


        //        ad = ad.Where(x => x.Price >= from);


        //        ad = ad.Where(x => x.Price <= to);


        //    return View(ad.ToList());
        //}
        //[HttpPost]
        //public ActionResult Index(int from, int to)
        //{
        //    if (!String.IsNullOrEmpty(from.ToString()))
        //    {

        //        ad = ad.Where(x => x.Price >= from);

        //    }
        //    if (!String.IsNullOrEmpty(to.ToString()))
        //    {

        //        ad = ad.Where(x => x.Price <= to);

        //    }
        //    return View(ad.ToList());
        //}
        public ActionResult NoItems()
        {
            
            return View();
        }
        public ActionResult Test(string size, string brand, string condition, string color, string price1, string price2, int? page)
        {

            var ad = from s in db.Ad
                     select s;
            if (ad == null)
            {
                return RedirectToAction("NoItems", "Catalog");
            }

            var SizeLst = new List<string>();

            var SizeQry = from d in db.Size
                          orderby d.Name
                          select d.Name;

            SizeLst.AddRange(SizeQry.Distinct());
            ViewBag.size = new SelectList(SizeLst);

            var IdSize = from d in db.Size
                         where (d.Name == size)
                         select d.Id;

            var BrandLst = new List<string>();

            var BrandQry = from d in db.Brand
                           orderby d.Name
                           select d.Name;

            BrandLst.AddRange(BrandQry.Distinct());
            ViewBag.brand = new SelectList(BrandLst);

            var IdBrand = from d in db.Brand
                          where (d.Name == brand)
                          select d.Id;
            var ConditionLst = new List<string>();

            var ConditionQry = from d in db.Condition
                               orderby d.Name
                               select d.Name;

            ConditionLst.AddRange(ConditionQry.Distinct());
            ViewBag.condition = new SelectList(ConditionLst);

            var IdCondition = from d in db.Condition
                              where (d.Name == condition)
                              select d.Id;

            var ColorLst = new List<string>();

            var ColorQry = from d in db.Color
                           orderby d.Name
                           select d.Name;

            ColorLst.AddRange(ColorQry.Distinct());
            ViewBag.color = new SelectList(ColorLst);

            var IdColor = from d in db.Brand
                          where (d.Name == color)
                          select d.Id;

            //var PriceFromLst = new List<string>();

            //var PriceFromQry = from d in db.Ad
            //               orderby d.Price
            //               select d.Price;

            //PriceFromLst.AddRange(PriceFromQry.Distinct());
            //ViewBag.color = new SelectList(ColorLst);

            //var IdColor = from d in db.Brand
            //              where (d.Name == color)
            //              select d.Id;
            List<SelectListItem> Price = new List<SelectListItem>();
            Price.Add(new SelectListItem() { Text = "50", Value = "50" });
            Price.Add(new SelectListItem() { Text = "90", Value = "90" });
            Price.Add(new SelectListItem() { Text = "150", Value = "150" });

            ViewBag.price1 = new SelectList(Price, "Value", "Text");
            ViewBag.price2 = new SelectList(Price, "Value", "Text");


            if (!String.IsNullOrEmpty(size))
            {
                int idSize = (from d in db.Size
                              where (d.Name == size)
                              select d.Id).Max();
                ad = ad.Where(x => x.SizeId == idSize);
            }
            if (!String.IsNullOrEmpty(condition))
            {
                int idCondition = (from d in db.Condition
                                   where (d.Name == condition)
                                   select d.Id).Max();
                ad = ad.Where(x => x.ConditionId == idCondition);
            }

            if (!String.IsNullOrEmpty(color))
            {
                int idColor = (from d in db.Color
                               where (d.Name == color)
                               select d.Id).Max();
                ad = ad.Where(x => x.ColorId == idColor);
            }

            if (!String.IsNullOrEmpty(brand))
            {
                int idBrand = (from d in db.Brand
                               where (d.Name == brand)
                               select d.Id).Max();
                ad = ad.Where(x => x.BrandId == idBrand);

            }

            if (!String.IsNullOrEmpty(price1))
            {
                float from = float.Parse(price1);
                ad = ad.Where(x => x.Price >= from);

            }
            if (!String.IsNullOrEmpty(price2))
            {
                float to = float.Parse(price2);
                ad = ad.Where(x => x.Price <= to);

            }
            ad = ad.OrderByDescending(s => s.Id);
            return View(ad.ToList().ToPagedList(page ?? 1, 9));
        }
    }
}