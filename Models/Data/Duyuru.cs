using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZHYR_Library.Models.Data
{
    public class Duyuru
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Image"), StringLength(256)]
        public string image { get; set; }
        public string Title { get; set; }
        [Required]
        [Display(Name = "Content")]
        public string content { get; set; }
        [Display(Name = "Duyru date"), DataType(DataType.DateTime)]
        public DateTime? date { get; set; }

        [Display(Name = "Created date")]
        [Column(TypeName = "datetime2")]
        public DateTime Created_at { get; set; }
        [Display(Name = "Updated date")]
        public DateTime? Updated_at { get; set; }
        [Display(Name = "Deleted date")]
        public DateTime? Deleted_at { get; set; }

    }
}