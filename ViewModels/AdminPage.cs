using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZHYR_Library.Models.Data;

namespace ZHYR_Library.ViewModels
{
    public class AdminPage
    {
        public List<books> List_books { get; set; }
        public books books { get; set; }
        public IEnumerable<books>  IE_Books { get; set; }
        public List<AspNetUsers> List_Users { get; set; }
        public AspNetUsers Users { get; set; }
        public IEnumerable<AspNetUsers> IE_Users { get; set; }
        public List<AspNetRoles> List_Roles { get; set; }
        public AspNetRoles Roles { get; set; }
        public IEnumerable<AspNetRoles> IE_Roles { get; set; }
        public List<categories> List_categories { get; set; }
        public categories categories { get; set; }
        public IEnumerable<categories> IE_categories { get; set; }
        public List<writers> List_writers { get; set; }
        public writers writers { get; set; }
        public IEnumerable<books> IE_writers { get; set; }
        public List<Slider> List_Slider { get; set; }
        public Slider Slider { get; set; }
        public IEnumerable<Slider> IE_Slider { get; set; }
        public List<images> List_images { get; set; }
        public images images { get; set; }
        public IEnumerable<books> IE_images { get; set; }
        public List<Duyuru> List_Duyuru { get; set; }
        public Duyuru Duyuru { get; set; }
        public IEnumerable<Duyuru> IE_Duyuru { get; set; }
        public List<Referans> Referans { get; set; }
        public Referans List_Referans { get; set; }
        public IEnumerable<Referans> IE_Referans { get; set; }
        public List<Post> List_Post { get; set; }
        public Post Post { get; set; }
        public IEnumerable<Post> IE_Post { get; set; }
    }
}