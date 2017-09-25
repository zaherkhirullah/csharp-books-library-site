using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZHYR_Library.Models.Data
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Slide Image"), StringLength(256)]
        public string image { get; set; }
        public string Title { get; set; }
        public string content { get; set; }
        [Display(Name = "start date"), DataType(DataType.DateTime)]
        public DateTime? f_date { get; set; }
        [Display(Name = "finish date"), DataType(DataType.DateTime)]
        public DateTime? l_date { get; set; }
        [Display(Name = "Created date")]
        public DateTime Created_at { get; set; }
        [Display(Name = "Updated date")]
        public DateTime? Updated_at { get; set; }
        [Display(Name = "Deleted date")]
        public DateTime? Deleted_at { get; set; }
    }
    
}