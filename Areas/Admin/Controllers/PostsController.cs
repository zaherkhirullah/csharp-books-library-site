
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
    public class PostsController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();
        private FileControl fileCntrl = new FileControl();
        private string path_img = "~/Uploads/images/Posts/";

        // GET: Admin/Posts
        public ActionResult Index()
        {
            var post = db.Post.Include(p => p.AspNetUsers).Include(p => p.categories)
                .OrderByDescending(x => x.Updated_at)
                .OrderByDescending(x => x.Created_at);
            return View(post.ToList());
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,content,category_id")] Post posts,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    posts.image = fileCntrl.fileUpload_withName(file, path_img, posts.Title + "_img_Post");
                }
                posts.Created_at = DateTime.Now;
                posts.UserId = User.Identity.GetUserId<int>();
                db.Post.Add(posts);
                db.SaveChanges();
                TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = posts.Title + "\t  Successfully Created ." };
                return RedirectToAction("Index");
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error !!  ", Message = posts.Title + "\t Failed Create . " };
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", post.UserId);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", posts.category_id);
            return View(posts);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", post.UserId);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", post.category_id);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,content,image,Created_at,Updated_at,category_id")] Post posts , HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    if (posts.image != null)
                    {
                        fileCntrl.DeleteOldFile(path_img, posts.image);
                    }
                    posts.image = fileCntrl.fileUpload_withName(file, path_img, posts.Title + "_img_Book");
                }

                posts.Updated_at = DateTime.Now;
                posts.UserId = User.Identity.GetUserId<int>();
                db.Entry(posts).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = posts.Title + "\t  Successfully Edited ." };
                return RedirectToAction("Index");
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error !!  ", Message = posts.Title + "\t Failed Edit . " };
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", post.UserId);
            ViewBag.category_id = new SelectList(db.categories, "id", "category_name", posts.category_id);
            return View(posts);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Post.Find(id);
            db.Post.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            var posts = db.Post.Include(b => b.categories);
            return View(posts.ToList());
        }
        // POST: Admin/books/Delete/5
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAllConfirmed()
        {
            var postss = db.Post.ToList();
            foreach (var posts in postss)
            {
                if (posts.image != null)
                {
                    fileCntrl.DeleteOldFile(path_img, posts.image);
                }
               
                db.Post.Remove(posts);
                db.SaveChanges();
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :)  ", Message = " All Posts  Successfully Deleted ." };
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
