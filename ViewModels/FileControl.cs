using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.SqlServer;
using System.Data.Entity;
using System.Web.Mvc;

namespace ZHYR_Library.ViewModels
{

    public class FileControl 
    {
        Random rand;
        public FileControl()
        {
            rand = new Random();
        }
        public void DeleteOldFile(string Url ,string Deletefile)
        {
            string oldPath = HttpContext.Current.Server.MapPath(Url);
            string DeleteTheFile = Path.Combine(oldPath, Deletefile);

            File.Delete(DeleteTheFile);
         
        }
        public string ToSafeFileName(string s)
        {
            return s
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }

        public string UploadError(string Error)
        {  /* if want return hata message 
               * if(categories.image == "NoFile")
                  {
                  ModelState.AddModelError("image", "image Must be ");
                 } 
               */
            string errorMessage = "";
            switch (Error)
            {
                case "image":
                    errorMessage = "image Must be .jpge,jpg,png,gif";
                    break;
                case "pdf":
                    errorMessage = "image Must be .pdf";
                    break;
                default:
                    errorMessage =" ";
                    break;
            }
            return errorMessage;
        }
        public string fileUpload(HttpPostedFileBase file, string Url)
        {
            if (file != null || file.ContentLength > 0)
            {
                int random = rand.Next(999);
                var name = "ZHYR_" + (DateTime.Now.Millisecond * random) // Add Number  to name
                                   + DateTime.Now.Minute                 // Add minutes to name
                                   + Path.GetExtension(file.FileName);   // get the type Extension from uploded File
                var SafedName = ToSafeFileName(name);
                var UploadUrl = HttpContext.Current.Server.MapPath(Url);
                var path = Path.Combine(UploadUrl, SafedName);
                file.SaveAs(path);
                return SafedName;
            }
            else
            {
                return null;
            }
        }
        public string fileUpload_withName(HttpPostedFileBase file, string Url,string Name)
        {
            //fileUpload(file ,Url);
            if (file != null)
            {
                int random = rand.Next(999);
                var name = Name +"_"+ (DateTime.Now.Millisecond * random) // Add Number  to name
                                   + DateTime.Now.Minute                 // Add minutes to name
                                   + Path.GetExtension(file.FileName);   // get the type Extension from uploded File
                var SafedName = ToSafeFileName(name);
                var UploadUrl = HttpContext.Current.Server.MapPath(Url);
                var path = Path.Combine(UploadUrl, SafedName);
                file.SaveAs(path);
                return SafedName;
            }
            else
            {
                return null;
            }
        }
        public string fileUploaded_ForEdit(HttpPostedFileBase file,string Url)
        { 
            var imageName="failed";
            return imageName;
        }
    }
}