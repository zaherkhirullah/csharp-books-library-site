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
using ZHYR_Library.Models;
using ZHYR_Library.Models.EFData;
using System.ComponentModel.DataAnnotations;

namespace ZHYR_Library.Controllers
{
    public class HomeController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();
        private ZHYR_EF_DB E_db = new ZHYR_EF_DB();
        private Homepage homePage = new Homepage();
        private List<books> books;
        public ActionResult Index()
        {
            homePage.Books = db.books.OrderByDescending(x => x.Created_at).ToList();
            homePage.TopDownloaded10 = E_db.TopDownloaded10.ToList();
            homePage.TopDownloaded100 = E_db.TopDownloaded100.ToList();
            homePage.TopReaded10 = E_db.TopReaded10.ToList();
            homePage.TopReaded100 = E_db.TopReaded100.ToList();
            homePage.TopLiked10 = E_db.TopLiked10.ToList();
            homePage.TopLiked100 = E_db.TopLiked100.ToList();
            homePage.TopPosts10 = E_db.TopPosts10.ToList();
            homePage.TopPosts100 = E_db.TopPosts100.ToList();
            homePage.Categories = db.categories.OrderByDescending(x => x.books.Count()).Take(8).ToList();
            homePage.Writers = db.writers.OrderByDescending(x => x.Created_at).Take(20).ToList();
            homePage.images = db.images.OrderByDescending(x => x.Created_at).ToList();
            homePage.Slider = db.Slider.Where(x => (x.f_date <= DateTime.Now && x.l_date > DateTime.Now)).ToList();
            homePage.Duyuru = db.Duyuru.OrderByDescending(x => x.date).Take(3).ToList();
            homePage.Referans = db.Referans.OrderByDescending(x => x.date).Take(3).ToList();
            homePage.Post = db.Post.OrderByDescending(x => x.Readed).Take(4).ToList();
            return View(homePage);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";
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
                TempData["Message"] = new MessageVm() { CssClassName = "alert-success", Title = "Success :) ", Message = "    Successfully Sended. " };
                return View();
            }
            TempData["Message"] = new MessageVm() { CssClassName = "alert-danger", Title = "Error !! ", Message = "    failed Sended ." };
            return View(contacts);
        }
        public ActionResult Blog()
        {
           var posts = db.Post.OrderByDescending(x => x.Created_at).ToList();
            return View(posts);
        }
        public ActionResult Books()
        {
            books = db.books.OrderByDescending(x => x.Created_at).ToList();
            return View(books);
        }
        public PartialViewResult All()
        {
            books = db.books.ToList();
            return PartialView("_Books", books);
        }
        public PartialViewResult Top3()
        {
            books = db.books.OrderByDescending(x => x.Liked).Take(3).ToList();
            return PartialView("_Books", books);
        }
        public PartialViewResult Top10()
        {
            var topLiked = E_db.TopLiked10.ToList();
            return PartialView("_Books", topLiked);
        }
        public PartialViewResult TopDownloaded()
        {
            var topDownloaded = E_db.TopDownloaded10.ToList();
            //  books = db.books.OrderByDescending(x => x.downloaded).Take(10).ToList();
            return PartialView("_Books", topDownloaded);
        }
        public PartialViewResult TopReaded()
        {
            var topReaded = E_db.TopReaded10.ToList();
            //books = db.books.OrderByDescending(x => x.Readed).Take(10).ToList();
            return PartialView("_Books", topReaded);
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
            var categories = db.categories.OrderByDescending(x => x.books.Count()).ToList();
            return View(categories);
        }
        public ActionResult Writers()
        {
            var writers = db.writers.OrderByDescending(x => x.books.Count()).ToList();
            return View(writers);
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
            else
            {
              if (User.Identity.GetUserId<int>() != books.UserId)
              {
                books.Readed++;
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
              }
            }
            return View(books);
        }
        public ActionResult post_details(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post posts = db.Post.Find(id);
            if (id == default(int))
            {
                return HttpNotFound();
            }
            if (User.Identity.GetUserId<int>() != posts.UserId)
            {
                //posts.Readed++;
                db.Entry(posts).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(posts);
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
       
        public ActionResult cPosts(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categories category = db.categories.Find(id);
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
            writers writer = db.writers.Find(id);
            //var books = db.books.Where(b => b.author_id == writer.id);

            if (id == default(int))
            {
                return HttpNotFound();
            }
            //return View(books.ToList());
            return View(writer);
        }

        public string LikedBook(int id)
        {
            books book = db.books.FirstOrDefault(x => x.id == id);
            if (ModelState.IsValid)
            {
                book.Liked++;
                Likes Like = new Likes();
                Like.UserId = User.Identity.GetUserId<int>();
                Like.Book_id = id;
                Like.Created_at = DateTime.Now;
                Like.Liked = true;
                db.Likes.Add(Like);
                db.SaveChanges();
            }
            return book.Likes.ToString();
        }
        public string UnLikedBook(int id)
        {
            books book = db.books.FirstOrDefault(x => x.id == id);
            if (ModelState.IsValid)
            {
                Likes Liked = db.Likes.FirstOrDefault(x => x.Book_id == id && x.UserId == User.Identity.GetUserId<int>());
                book.Liked--;
                db.Likes.Remove(Liked);
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
        public ActionResult Liked(Likes Likes, int id)
        {
            if (ModelState.IsValid)
            {
                books books = db.books.Find(id);
                if (Likes.Book_id == books.id && Likes.UserId == User.Identity.GetUserId<int>())
                {
                    books.Liked--;
                    db.Likes.Remove(Likes);
                    db.SaveChanges();
                    return RedirectToAction("Book_details");
                }
                else
                {
                    Likes.UserId = User.Identity.GetUserId<int>();
                    Likes.Book_id = books.id;
                    Likes.Created_at = DateTime.Now;
                    books.Liked++;
                    db.Likes.Add(Likes);
                    db.SaveChanges();
                }
            }
            return View("Book_details", "Home", new { id = id });
        }

        //[HttpPost, ActionName("Book_details")]
        //[ValidateAntiForgeryToken]
        //public ActionResult UnLikedBook1( int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        books books = db.books.Find(id);
        //        Likes Likes = db.Likes.FirstOrDefault(s => s.Book_id == books.id || s.UserId == User.Identity.GetUserId<int>());               
        //        books.Liked--;
        //        db.Likes.Remove(Likes);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Book_details", "Home", new { id = id });
        //}

        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddUser(string UserName, string Email, string Password, string ConfirmPassword)
        {
            var user = new RegisterViewModel();
            user.UserName = UserName;
            user.Email = Email;
            user.Password = Password;
            user.ConfirmPassword = ConfirmPassword;
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult CreateComment(comments comment, int id)
        {
            if (ModelState.IsValid)
            {
                books books = db.books.Find(id);
                comment.UserId = User.Identity.GetUserId<int>();
                comment.BookId = books.id;
                comment.comment = comment.comment;
                comment.Created_at = DateTime.Now;
                db.comments.Add(comment);
                db.SaveChanges();
            }
            return PartialView("Book_details", comment);
        }


        [HttpPost, ActionName("AddCommentPartial")]
        [ValidateAntiForgeryToken]
        public PartialViewResult AddCommentPartial(int id)
        {
            books book = db.books.FirstOrDefault(x => x.id == id);
            if (ModelState.IsValid)
            {
                comments comment = new comments();
                comment.UserId = User.Identity.GetUserId<int>();
                comment.BookId = id;
                comment.Created_at = DateTime.Now;
                db.comments.Add(comment);
                db.SaveChanges();
            }
            return PartialView("_Book_Comments", books);
        }

        #region //  Comments with javascript ajax

        public JsonResult AddComment(string Comment, int id)
        {
            var comment = new comments();
            if (ModelState.IsValid)
            {
                comment.comment = Comment;
                comment.Created_at = DateTime.Now;
                comment.BookId = id;
                comment.UserId = User.Identity.GetUserId<int>();
                db.comments.Add(comment);
                db.SaveChanges();
            }
            return Json(comment, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditComment(string Comment, int id)
        {
            var comment = db.comments.Find(id);
            comment.BookId = comment.BookId;
            comment.UserId = comment.UserId;
            if (ModelState.IsValid)
            {
                comment.comment = Comment;
                comment.Updated_at = DateTime.Now;
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(comment, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteComment(int id)
        {
            var comment = db.comments.Find(id);
            if (ModelState.IsValid)
            {
                db.comments.Remove(comment);
                db.SaveChanges();
            }
            return Json(comment.comment, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region   // Likes with Ajax


        public JsonResult Liked_it(int id)
        {
            books books = db.books.Find(id);
                Likes like = new Likes();
                    if (ModelState.IsValid)
                    {
                        like.UserId = User.Identity.GetUserId<int>();
                        like.Book_id = books.id;
                        like.Liked = true;
                        like.Created_at = DateTime.Now;
                        books.Liked++;
                        db.Likes.Add(like);
                        db.SaveChanges();
                    }
                
          return Json(books.Liked, JsonRequestBehavior.AllowGet);
}

public JsonResult UnLiked_it(int id)
{
    books books = db.books.Find(id);
  var likes = db.Likes.SingleOrDefault(x => x.Book_id == books.id && x.UserId == User.Identity.GetUserId<int>());
    if (ModelState.IsValid)
    {books.Liked--;
        db.Likes.Remove(likes);
        db.SaveChanges();
    }
    return Json(likes, JsonRequestBehavior.AllowGet);
}

        #endregion

    }
}