using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZHYR_Library.Models.Data;
using ZHYR_Library.ViewModels;

namespace ZHYR_Library.Areas.Admin.Controllers
{
    public class imagesController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();
        private FileControl filCntrl = new FileControl();

        public FileControl FilCntrl { get => filCntrl; set => filCntrl = value; }

        // GET: Admin/images
        public ActionResult Index()
        {
            return View(db.images.ToList());
        }

        // GET: Admin/images/Details/5
        public ActionResult Details(int id)
        {
             if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            images images = db.images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }
            return View(images);
        }

        // GET: Admin/images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "image_name,image_about")] images images,HttpPostedFileBase file)
        {
            
            if (ModelState.IsValid)
            {
                images.image = FilCntrl.fileUpload_withName(file ,"~/Uploads/images/images/","image");
                images.UserId = User.Identity.GetUserId<int>();
                images.Created_at = DateTime.Now;
                db.images.Add(images);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(images);
        }

        // GET: Admin/images/Edit/5
        public ActionResult Edit(int id)
        {
             if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            images images = db.images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }
            return View(images);
        }

        // POST: Admin/images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,image_name,image_about,Created_at")] images images , HttpPostedFileBase file )
        {
            if (ModelState.IsValid)
            {
                images.image = FilCntrl.fileUpload_withName(file, "~/Uploads/images/images/", "image");
                images.UserId = User.Identity.GetUserId<int>();
                images.Updated_at = DateTime.Now;
                db.Entry(images).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(images);
        }

        // GET: Admin/images/Delete/5
        public ActionResult Delete(int id)
        {
             if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            images images = db.images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }
            return View(images);
        }

        // POST: Admin/images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            images images = db.images.Find(id);
            db.images.Remove(images);
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
