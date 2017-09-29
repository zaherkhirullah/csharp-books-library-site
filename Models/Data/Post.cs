using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZHYR_Library.Models.Data
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Image"), StringLength(256)]
        public string image { get; set; }
        public string Title { get; set; }
        [Required]
        [Display(Name = "Content")]
        public string content { get; set; }

        public DateTime? date { get; set; }
        public int Liked { get; set; }
        public int disLike { get; set; }
        public int Readed { get; set; }
        [Display(Name = "Created date")]
        [Column(TypeName = "datetime2")]
        public DateTime Created_at { get; set; }
        [Display(Name = "Updated date")]
        public DateTime? Updated_at { get; set; }
        [Display(Name = "Deleted date")]
        public DateTime? Deleted_at { get; set; }

        [ForeignKey("categories")]
        public int category_id { get; set; }
        public virtual categories categories { get; set; }
        [Required]
         [ForeignKey("AspNetUsers")]
        public int UserId { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual ICollection<comments> comments { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }


    }
}