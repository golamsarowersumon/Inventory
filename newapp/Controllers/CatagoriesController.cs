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
    public class CatagoriesController : Controller
    {
        private dbmodel db = new dbmodel();

        // GET: Catagories
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult allcatagory()
        {
            var all = db.Catagories.ToList();
            return Json(all, JsonRequestBehavior.AllowGet);
        }

        // GET: Catagories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = db.Catagories.Find(id);
            if (catagory == null)
            {
                return HttpNotFound();
            }
            return View(catagory);
        }

       
     
        // POST: Catagories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       
        public JsonResult Create(Catagory catagory)
        {
           
                db.Catagories.Add(catagory);
                db.SaveChanges();
               

            return Json(new { success = true });
        }

        // GET: Catagories/Edit/5
        public JsonResult GEtbyId(int? id)
        {
           
            Catagory catagory = db.Catagories.Find(id);
          
            return Json(catagory,JsonRequestBehavior.AllowGet);
        }

        // POST: Catagories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      
        public JsonResult Update(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catagory).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new { success=true});
        }

        // GET: Catagories/Delete/5

        // POST: Catagories/Delete/5
      
        public JsonResult DeleteConfirmed(int id)
        {
            
            db.Catagories.Remove(db.Catagories.Find(id));
            db.SaveChanges();
            return Json(new { success=true});
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
