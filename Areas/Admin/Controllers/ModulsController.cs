using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZHYR_Library.Models.Data;

namespace ZHYR_Library.Areas.Admin.Controllers
{
    public class ModulsController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();

        // GET: Admin/Moduls
        public ActionResult Index()
        {
            return View(db.Modul.ToList());
        }

        // GET: Admin/Moduls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Modul.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // GET: Admin/Moduls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Moduls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,image,Title,content,date")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                modul.Created_at = DateTime.Now;
                db.Modul.Add(modul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modul);
        }

        // GET: Admin/Moduls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Modul.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // POST: Admin/Moduls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,image,Title,content,date,Created_at")] Modul modul)
        {
            if (ModelState.IsValid)
            { modul.Updated_at = DateTime.Now;
                db.Entry(modul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modul);
        }

        // GET: Admin/Moduls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Modul.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // POST: Admin/Moduls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modul modul = db.Modul.Find(id);
            db.Modul.Remove(modul);
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
