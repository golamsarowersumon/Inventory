using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using newapp.Models;

namespace newapp.Controllers
{
    public class ProductsController : Controller
    {
        private dbmodel db = new dbmodel();

        // GET: Products
        public ActionResult Index()
        {
         
            return View();
        }
        public JsonResult AllProduct()
        {
            
            var data = from p in db.Products
                       join c in db.Catagories on p.CatagoryId equals c.CatagoryId
                       select new
                       {
                           PId = p.ProductId,
                           CatName = c.CName,
                           PName = p.PName
                       };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult allcatagory()
        {
            var all = db.Catagories.ToList();
            return Json(all, JsonRequestBehavior.AllowGet);
        }
        // GET: Products/Details/5
        public JsonResult Details(int? id)
        {

            var data = from p in db.Products
                       join c in db.Catagories on p.CatagoryId equals c.CatagoryId where p.ProductId==id
                       select new
                       {
                           PId = p.ProductId,
                           CatName = c.CName,
                           PName = p.PName
                       };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

      
        public JsonResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
               
            }

           
            return Json(new { success=true});
        }


        public JsonResult GEtbyId(int? id)
        {

           
          

          var  prd =  from p in db.Products
                       join c in db.Catagories on p.CatagoryId equals c.CatagoryId where p.ProductId ==id
                       select new Vm
                       {
                           ProductId = p.ProductId,
                           CatagoryId =c.CatagoryId,
                           CName = c.CName,
                           PName = p.PName
                       };
            
            return Json(prd,JsonRequestBehavior.AllowGet);

            //Product product = db.Products.Find(id);

            //return Json(product, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
               
            }
           
            return Json(new { success=true});
        }

     
        public JsonResult DeleteConfirmed(int id)
        {
           
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
