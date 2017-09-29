using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ZHYR_Library.Models.Data;
using ZHYR_Library.ViewModels;
using System.IO;

namespace ZHYR_Library.Areas.Admin
{
    public class booksController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();
        private FileControl fileCntrl = new FileControl();
        private string path_img = "~/Uploads/images/Books/";
        private string path_pdf = "~/Uploads/Books/";

        // GET: Admin/books
        public ActionResult Index(string search, string filter)
        {//var books = db.books.Include(b => b.AspNetUsers).Include(b => b.categories).Include(b => b.writers);
            var books = db.books.Include(b => b.categories)
                .Include(b => b.writers)
                .OrderByDescending(x => x.Updated_at)
                .OrderByDescending(x => x.Created_at);
          
            if (search != null)
            {
                if (filter == "Name")
                {
                    books.Where(m => m.book_name.Contains(search)).ToList();
                    return View(books);
                }
                if (filter == "Category")
                {
                    books.Where(m => m.categories.category_name.Contains(search)).ToList();
                    return View(books);
                }
                if (filter == "Author")
                {
                    books.Where(m => m.writers.author_name.Contains(search)).ToList();
                    return View(books);
                }
            }
            return View(books.ToList());
        }

        // GET: Admin/books/Details/5
        public ActionResult Details(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (id == default(int))
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Admin/books/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name");
            ViewBag.author_id = new SelectList(db.writers, "id", "author_name");
            return View();
        }

        // POST: Admin/books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "book_name,book_about,author_id,category_id")] books books, HttpPostedFileBase file, HttpPostedFileBase path)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    books.image = fileCntrl.fileUpload_withName(file, path_img, books.book_name + "_img_Book");
                }
                if (path != null)
                {
                    books.book_path = fileCntrl.fileUpload_withName(path, path_pdf, books.book_name + "_Book");
                }
                books.Created_at = DateTime.Now;
                books.UserId = User.Identity.GetUserId<int>();
                db.books.Add(books);
                db.SaveChanges();
                TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = books.book_name + "\t  Successfully Created ." };
                return RedirectToAction("Index");
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error !!  ", Message = books.book_name + "\t Failed Create . " };
            
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", books.UserId);    ViewBag.category_id = new SelectList(db.categories, "id", "category_name", books.category_id);
            ViewBag.author_id = new SelectList(db.writers, "id", "author_name", books.author_id);
            return View(books);
        }

        // GET: Admin/books/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", books.UserId);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", books.category_id);
            ViewBag.author_id = new SelectList(db.writers, "id", "author_name", books.author_id);
            return View(books);
        }

        // POST: Admin/books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,book_name,book_about,author_id,category_id,Created_at,image,book_path")] books books, HttpPostedFileBase file, HttpPostedFileBase path)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    if (books.image != null)
                    {
                        fileCntrl.DeleteOldFile(path_img, books.image);
                    }
                    books.image = fileCntrl.fileUpload_withName(file, path_img, books.book_name + "_img_Book");
                }
                if (path != null)
                {
                    if (books.book_path != null)
                    {    
                        //string oldPath_pdf = Path.Combine(Server.MapPath(path_pdf), books.book_path);
                        //System.IO.File.Delete(oldPath_pdf);
                        fileCntrl.DeleteOldFile(path_pdf, books.book_path);
                    }
                    books.book_path = fileCntrl.fileUpload_withName(path,path_pdf, books.book_name + "_Book");
                }

                books.Updated_at = DateTime.Now;
                books.UserId = User.Identity.GetUserId<int>();
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = books.book_name + "\t  Successfully Edited ." };
                return RedirectToAction("Index");
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error !!  ", Message = books.book_name + "\t Failed Edit . " };
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "UserName", books.UserId);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", books.category_id);
            ViewBag.author_id = new SelectList(db.writers, "id", "author_name", books.author_id);
            return View(books);
        }

        // GET: Admin/books/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Admin/books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            books books = db.books.Find(id);
            if (books.image != null)
            {
                fileCntrl.DeleteOldFile(path_img, books.image);
            }
            if (books.book_path != null)
            {
                fileCntrl.DeleteOldFile(path_pdf, books.book_path);
            }
            db.books.Remove(books);
            db.SaveChanges();
            TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = books.book_name + "    Successfully Deleted ." };
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            var books = db.books.Include(b => b.categories).Include(b => b.writers);
            return View(books.ToList());
        }
        // POST: Admin/books/Delete/5
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAllConfirmed()
        {
            var bookss = db.books.ToList();
            foreach (var books in bookss)
            {
                if (books.image != null)
                {
                    fileCntrl.DeleteOldFile(path_img, books.image);
                }
                if (books.book_path != null)
                {
                    fileCntrl.DeleteOldFile(path_pdf, books.book_path);
                }
                db.books.Remove(books);
                db.SaveChanges();
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message =" All Books   Successfully Deleted ." };
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
