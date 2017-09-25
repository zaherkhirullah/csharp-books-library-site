using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZHYR_Library.Models.Data;

namespace ZHYR_Library.ViewModels
{
    public class Homepage
    {
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