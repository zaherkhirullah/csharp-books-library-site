using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZHYR_Library.Models;
using ZHYR_Library.Models.Data;
using ZHYR_Library.ViewModels;

namespace ZHYR_Library.Areas.Admin.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ZHYRBooks db = new ZHYRBooks();
        private FileControl fileCntrl = new FileControl();
        private string path_img = "~/Uploads/images/Users/images";
        private string path_cover = "~/Uploads/images/Users/covers";


        // GET: Admin/User
        public ActionResult Index(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers users = db.AspNetUsers.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }


        // GET: Admin/User/Details/5


        // GET: Admin/User/Create


        // POST: Admin/User/Create


        // GET: Admin/User/Edit/5


        // POST: Admin/User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AspNetUsers user, HttpPostedFileBase file, HttpPostedFileBase cover)
        {
            var _user = db.AspNetUsers.Where(x => x.Id == user.Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    if (user.avatar != null)
                    {
                        fileCntrl.DeleteOldFile(path_img, user.avatar);
                    }
                    _user.avatar = fileCntrl.fileUpload_withName(file,  path_img,_user.UserName);
                }
                if (cover != null)
                {
                    if (user.cover != null)
                    {
                        fileCntrl.DeleteOldFile(path_cover, user.cover);
                    }
                    _user.cover = fileCntrl.fileUpload_withName(cover, path_cover, _user.UserName);
                }
                _user.Adress = user.Adress;
                _user.FullName = user.FullName;
                _user.status = user.status;
                _user.PhoneNumber = user.PhoneNumber;
                _user.birth_date = user.birth_date;
                _user.Email = user.Email;
                _user.Created_at = user.Created_at;
                _user.Updated_at = DateTime.Now;
                db.SaveChanges();
                TempData["Message"] = new MessageVm() { Title = "success :)", CssClassName = "alert-success", Message = "Succesfuly Updated your Profile " };
                return RedirectToAction("Index","Admin");
            }

            return View(_user);
        }

        // GET: Admin/User/Delete/5


        // POST: Admin/User/Delete/5

    }
}
