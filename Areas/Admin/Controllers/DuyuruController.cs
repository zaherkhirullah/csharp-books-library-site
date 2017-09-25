using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZHYR_Library.Models.Data;

namespace ZHYR_Library.Areas.Admin.Controllers
{
    public class DuyuruController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();

        // GET: Admin/Duyurus
        public ActionResult Index()
        {
            return View(db.Duyuru.ToList());
        }

        // GET: Admin/Duyurus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // GET: Admin/Duyurus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Duyurus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,image,content,date")] Duyuru duyuru, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                duyuru.Created_at = DateTime.Now;
                db.Duyuru.Add(duyuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duyuru);
        }

        // GET: Admin/Duyurus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // POST: Admin/Duyurus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,content,date,Created_at")] Duyuru duyuru,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {   string oldPath_image = Path.Combine(Server.MapPath("~/Uploads/images/Duyurus"), duyuru.image);
                if (file != null)
                {
                    System.IO.File.Delete(oldPath_image);
                }
                duyuru.Updated_at = DateTime.Now;
                db.Entry(duyuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duyuru);
        }

        // GET: Admin/Duyurus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // POST: Admin/Duyurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Duyuru duyuru = db.Duyuru.Find(id);
            db.Duyuru.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
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
