using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZHYR_Library.Models.Data;
using ZHYR_Library.Models.EFData;

namespace ZHYR_Library.ViewModels
{
    public class UserPages
    {
       
        public List<AspNetUsers> List_Users { get; set; }
        public AspNetUsers Users { get; set; }
        public IEnumerable<AspNetUsers> IE_Users { get; set; }
       
    }
}