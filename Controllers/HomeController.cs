using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZHYR_Library.Models.Data;
using ZHYR_Library.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace ZHYR_Library.Controllers
{
    public class HomeController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();
        private Homepage homePage = new Homepage();
        private List<books> books;
        public ActionResult Index()
        {
            homePage.Books = db.books.OrderByDescending(x =>x.Created_at).ToList();
            homePage.Categories = db.categories.OrderByDescending(x => x.Created_at).ToList();
            homePage.Writers = db.writers.OrderByDescending(x => x.Created_at).ToList();
            homePage.images = db.images.OrderByDescending(x => x.Created_at).ToList();
            homePage.Slider = db.Slider.Where(x => (x.f_date <= DateTime.Now && x.l_date > DateTime.Now)).ToList();
            homePage.Duyuru = db.Duyuru.OrderByDescending(x => x.date).Take(3).ToList();
            homePage.Referans = db.Referans.OrderByDescending(x => x.date).Take(3).ToList();
            homePage.Post = db.Post.OrderByDescending(x => x.date).Take(3).ToList();
            return View(homePage);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
             return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "FullName,email,massege")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                contacts.Created_at = DateTime.Now;
                db.Contacts.Add(contacts);
                db.SaveChanges();
                TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success!  ", Message = "    Successfully Sended :)" };
                return View();
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error!  ", Message = "    failed Sended :)" };

            return View(contacts);
        }

        public ActionResult Books()
        {
            return View();
        }
        public PartialViewResult All()
        {
             books = db.books.ToList();
            return PartialView("_Books", books);
        }
        public PartialViewResult Top3()
        {
           books = db.books.OrderByDescending(x => x.Like).Take(3).ToList();
            return PartialView("_Books", books);
        }
        public PartialViewResult Top10()
        {
           books = db.books.OrderByDescending(x => x.Like).Take(10).ToList();
            return PartialView("_Books", books);
        }
        public PartialViewResult TopDownloaded()
        {
           books = db.books.OrderByDescending(x => x.downloaded).Take(10).ToList();
            return PartialView("_Books", books);
        }
        public PartialViewResult TopReaded()
        {
            books = db.books.OrderByDescending(x => x.Readed).Take(10).ToList();
            return PartialView("_Books", books);
        }
        public PartialViewResult TopFavorited()
        {
            books = db.books.OrderByDescending(x => x.favorited).Take(10).ToList();
            return PartialView("_Books", books);
        }
        public PartialViewResult disLike()
        {
             books = db.books.OrderByDescending(x => x.disLike).Take(10).ToList();
            return PartialView("_Books", books);
        }
        public ActionResult categories()
        {
            return View(db.categories.ToList());
        }
        public ActionResult Writers()
        {

            return View(db.writers.ToList());
        }
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Icons()
        {

            return View();
        }
        public ActionResult Book_details(int id)
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
            if (User.Identity.GetUserId<int>() != books.UserId)
            {
                books.Readed++;
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(books);
        }
        public ActionResult Category_Books(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categories category = db.categories.Find(id);
            //var books = db.books.Where(b => b.category_id == category.id);
            if (id == default(int))
            {
               return HttpNotFound();
            }
            return View(category);
        }
        public ActionResult Writer_Books(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //categories category = db.categories.Find(id);
            writers writer= db.writers.Find(id);
            //var books = db.books.Where(b => b.author_id == writer.id);

            if (id == default(int))
            {
                return HttpNotFound();
            }
            //return View(books.ToList());
            return View(writer);
        }

        public string LikeBook(int id)
        {
            books book = db.books.FirstOrDefault(x => x.id == id);
            if (ModelState.IsValid)
            {
                book.Like++;
                Likes like = new Likes();
                like.UserId = User.Identity.GetUserId<int>();
                like.Book_id = id;
                like.Created_at = DateTime.Now;
                like.Liked = true;
                db.Likes.Add(like);
                db.SaveChanges();
            }
            return book.Likes.ToString();
        }
        public string UnLikeBook(int id)
        {
            books book = db.books.FirstOrDefault(x => x.id == id);
            if (ModelState.IsValid)
            {
                Likes like = db.Likes.FirstOrDefault(x => x.Book_id == id && x.UserId == User.Identity.GetUserId<int>());
                book.Like--;
                db.Likes.Remove(like);
                db.SaveChanges();
            }
            return book.Likes.ToString();
        }
        //public string FavoriteBook(int id)
        //{
        //    books book = db.books.FirstOrDefault(x => x.id == id);
        //    if (ModelState.IsValid)
        //    {
        //        book.Favorite++;
        //        Favorites Favorite = new Favorites();
        //        Favorite.UserId = User.Identity.GetUserId<int>();
        //        Favorite.Book_id = id;
        //        Favorite.Created_at = DateTime.Now;
        //        Favorite.Favorited = true;
        //        db.Favorites.Add(Favorite);
        //        db.SaveChanges();
        //    }
        //    return book.Likes.ToString();
        //}
        //public string UnFavoriteBook(int id)
        //{
        //    books book = db.books.FirstOrDefault(x => x.id == id);
        //    if (ModelState.IsValid)
        //    {
        //        Favorites Favorite = db.Favorites.FirstOrDefault(x => x.Book_id == id && x.UserId == User.Identity.GetUserId<int>());
        //        book.Favorite--;
        //        db.Favorites.Remove(Favorite);
        //        db.SaveChanges();
        //    }
        //    return book.Likes.ToString();
        //}
        [HttpPost, ActionName("Book_details")]
        [ValidateAntiForgeryToken]
        public ActionResult LikeBook1(Likes likes, int id)
        {
            if (ModelState.IsValid)
            {
                books books = db.books.Find(id);
                likes.UserId = User.Identity.GetUserId<int>();
                likes.Book_id = books.id;
                likes.Created_at = DateTime.Now;
                books.Like++;
                db.Likes.Add(likes);
                db.SaveChanges();
            }
            return RedirectToAction("Book_details", "Home", new { id = id });
        }
        //[HttpPost, ActionName("Book_details")]
        //[ValidateAntiForgeryToken]
        //public ActionResult UnLikeBook1( int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        books books = db.books.Find(id);
        //        Likes likes = db.Likes.FirstOrDefault(s => s.Book_id == books.id || s.UserId == User.Identity.GetUserId<int>());               
        //        books.Like--;
        //        db.Likes.Remove(likes);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Book_details", "Home", new { id = id });
        //}

    }
}