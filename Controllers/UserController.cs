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
    [Authorize]
    public class UserController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();
        private UserPages userPages = new UserPages();
        private List<books> books;
        private int user;
        public ActionResult Index()
        {
            userPages.List_Users = db.AspNetUsers.OrderByDescending(x => x.Created_at).ToList();
            return View(userPages);
        }

        public ActionResult profile()
        {
            user = User.Identity.GetUserId<int>();
                var profile = db.AspNetUsers.FirstOrDefault(x => x.Id == user);
            return View(profile);
        }
        public ActionResult EditProfile(int id)
        {
            return View();
        }
        public ActionResult MyPosts()
        {
            user = User.Identity.GetUserId<int>();
            var posts = db.Post.Where(x => x.UserId == user).OrderByDescending(x => x.Created_at).ToList();
            return View(posts);
        }
        public ActionResult MyBooks()
        {
            user = User.Identity.GetUserId<int>();
            books = db.books.Where(x => x.UserId == user).OrderByDescending(x => x.Created_at).ToList();
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
            books = db.books.OrderByDescending(x => x.Liked).Take(10).ToList();
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
            user = User.Identity.GetUserId<int>();
            var categories = db.categories.Where(x => x.UserId == user).OrderByDescending(x => x.Created_at).ToList();
            return View(categories);
        }
        public ActionResult Writers()
        {
            user = User.Identity.GetUserId<int>();
            var writers = db.writers.Where(x => x.UserId == user).OrderByDescending(x => x.books.Count()).ToList();
            return View(writers);
        }
          public ActionResult Notafications()
        {
            user = User.Identity.GetUserId<int>();
            var writers = db.writers.Where(x => x.UserId == user).OrderByDescending(x => x.books.Count()).ToList();
            return View(writers);
        }

        
    }
}