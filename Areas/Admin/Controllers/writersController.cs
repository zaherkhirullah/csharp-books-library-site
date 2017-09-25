using Microsoft.AspNet.Identity;
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
using ZHYR_Library.ViewModels;

namespace ZHYR_Library.Areas.Admin.Controllers
{
    public class writersController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();
        private FileControl fileCntrl = new FileControl();
        private string path_img = "~/Uploads/images/writers/";

        // GET: Admin/writers
        public ActionResult Index()
        {
            var writers = db.writers.Include(w => w.AspNetUsers);
            return View(writers.ToList());
        }

        // GET: Admin/writers/Details/5
        public ActionResult Details(int id)
        {
             if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            writers writers = db.writers.Find(id);
            if (writers == null)
            {
                return HttpNotFound();
            }
            return View(writers);
        }

        // GET: Admin/writers/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: Admin/writers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "author_name,author_about,birth_date")] writers writers,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
               writers.image = fileCntrl.fileUpload_withName(file, path_img, writers.author_name + "_writer");
                writers.UserId = User.Identity.GetUserId<int>();
                writers.Created_at = DateTime.Now;
                db.writers.Add(writers);
                db.SaveChanges();
                TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = writers.author_name + "\t  Successfully Created ." };
                return RedirectToAction("Index");
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error !!  ", Message = writers.author_name + "\t Failed Create . " };
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", writers.UserId);
            return View(writers);
        }

        // GET: Admin/writers/Edit/5
        public ActionResult Edit(int id)
        {
             if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            writers writers = db.writers.Find(id);
            if (writers == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View(writers);
        }

        // POST: Admin/writers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,author_name,author_about,birth_date,Created_at,image")] writers writers,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    if (writers.image != null) { 
                        fileCntrl.DeleteOldFile(path_img, writers.image);
                            }
                    writers.image = fileCntrl.fileUpload_withName(file, "~/Uploads/images/writers/", writers.author_name + "_writer");
                }
                writers.UserId = User.Identity.GetUserId<int>();
                writers.Updated_at = DateTime.Now;
                db.Entry(writers).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = writers.author_name + "\t  Successfully Edited ." };
                return RedirectToAction("Index");
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error !!  ", Message = writers.author_name + "\t Failed Edit . " };
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", writers.UserId);
            return View(writers);
        }

        // GET: Admin/writers/Delete/5
        public ActionResult Delete(int id)
        {
             if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            writers writers = db.writers.Find(id);
            if (writers == null)
            {
                return HttpNotFound();
            }
            return View(writers);
        }

        // POST: Admin/writers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            writers writers = db.writers.Find(id);
            if (writers.image != null)
            {
                fileCntrl.DeleteOldFile(path_img, writers.image);
            }
            db.writers.Remove(writers);
            db.SaveChanges();
            TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = writers.author_name + "    Successfully Deleted ." };

            return RedirectToAction("Index");
        }
        public ActionResult DeleteAll()
        {
            var writers = db.writers.ToList();
            return View(writers);
        }
        // POST: Admin/books/Delete/5
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAllConfirmed()
        {
            var writers = db.writers.ToList();
            foreach (var Author in writers)
            {
                if (Author.image != null)
                {
                    fileCntrl.DeleteOldFile(path_img, Author.image);
                }
                db.writers.Remove(Author);
                db.SaveChanges();
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = " All Books   Successfully Deleted ." };
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
