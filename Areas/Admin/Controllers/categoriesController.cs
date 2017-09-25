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
    public class categoriesController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();
        private FileControl fileCntrl = new FileControl();
        private string path_img = "~/Uploads/images/categories/";
        // GET: Admin/categories
        public ActionResult Index()
        {
            var categories = db.categories.Include(c => c.AspNetUsers);
            return View(categories.ToList());
        }

        // GET: Admin/categories/Details/5
        public ActionResult Details(int id)
        {
             if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categories categories = db.categories.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }
        // GET: Admin/categories/Create
        public ActionResult Create()
        {
           //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }
   
        // POST: Admin/categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "category_name,category_about")] categories categories, HttpPostedFileBase file)
        {
            // Multiple images 
             //for (int i = 0; i < Request.Files.Count; i++)
             //{
             //    file = Request.Files[i];
             //    categories.image = fileCntrl.fileUpload_withName(file, "~/Uploads/images/categories/", "Category");
             //}
            if (ModelState.IsValid)
            {
                categories.image = fileCntrl.fileUpload_withName(file, path_img,categories.category_name + "_img_Category");        
                categories.Created_at = DateTime.Now;
                categories.UserId = User.Identity.GetUserId<int>();
                db.categories.Add(categories);
                db.SaveChanges();
               TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = categories.category_name + "\t  Successfully Created ." };
            return RedirectToAction("Index");
           }
        TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error !!  ", Message = categories.category_name + "\t Failed Create . " };
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", categories.UserId);
            return View(categories);
        }

        // GET: Admin/categories/Edit/5
        public ActionResult Edit(int id)
        {
             if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categories categories = db.categories.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", categories.UserId);
            return View(categories);
        }

        // POST: Admin/categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,category_name,category_about,Created_at,image")] categories categories, HttpPostedFileBase Newfile)
        {
            if (ModelState.IsValid)
            {
                if (Newfile != null)
                {
                    if (categories.image != null)
                    {
                        fileCntrl.DeleteOldFile(path_img, categories.image);
                    }
                    categories.image = fileCntrl.fileUpload_withName(Newfile, path_img, categories.category_name + "_img_Category");
                }
                categories.UserId = User.Identity.GetUserId<int>();
                categories.Updated_at = DateTime.Now;
                db.Entry(categories).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = categories.category_name + "\t  Successfully Edited ." };
                return RedirectToAction("Index");
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error !!  ", Message = categories.category_name + "\t Failed Edit . " };
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", categories.UserId);
            return View(categories);
        }

        // GET: Admin/categories/Delete/5
        public ActionResult Delete(int id)
        {
             if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categories categories = db.categories.Find(id);

            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Admin/categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categories categories = db.categories.Find(id);
            if (categories.image != null)
            {
                fileCntrl.DeleteOldFile(path_img, categories.image);
            }
            //var books_in_category = db.books.ToList();
            foreach (var book in categories.books)
            {
                db.books.Remove(book);
                db.SaveChanges();
            }
            db.categories.Remove(categories);
            db.SaveChanges();
            TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = categories.category_name + "    Successfully Deleted ." };

            return RedirectToAction("Index");
        }
        public ActionResult DeleteAll()
        {
            var categories = db.categories.ToList();
            return View(categories);
        }
        // POST: Admin/books/Delete/5
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAllConfirmed()
        {
            var categories = db.categories.ToList();
            foreach (var category in categories)
            {
                if (category.image != null)
                {
                    fileCntrl.DeleteOldFile(path_img, category.image);
                }
                db.categories.Remove(category);
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
