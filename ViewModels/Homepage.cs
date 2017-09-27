using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZHYR_Library.Models.Data;
using ZHYR_Library.Models.EFData;

namespace ZHYR_Library.ViewModels
{
    public class Homepage
    {
        public List<TopDownloaded10> TopDownloaded10 { get; set; }
        public List<TopDownloaded100> TopDownloaded100 { get; set; }
        public List<TopReaded10> TopReaded10 { get; set; }
        public List<TopReaded100> TopReaded100 { get; set; }
        public List<TopLiked10> TopLiked10 { get; set; }
        public List<TopLiked100> TopLiked100 { get; set; }
        public  List<TopPosts10> TopPosts10 { get; set; }
        public List<TopPosts100> TopPosts100 { get; set; }
        public List<books> Books { get; set; }
        public List<categories> Categories { get; set; }
        public List<writers> Writers { get; set; }
        public List<Slider> Slider { get; set; }
        public List<images> images { get; set; }
        public List<AspNetUsers> List_Users { get; set; }
        public AspNetUsers Users { get; set; }
        public IEnumerable<AspNetUsers> IE_Users { get; set; }
        public List<Duyuru> Duyuru { get; set; }
        public List<Referans> Referans { get; set; }
        public List<Post> Post { get; set; }
    }
}