using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZHYR_Library.Models.Data
{
    public class Likes
    {
        [Key]
        public int Id { get; set; }
        public bool Liked { get; set; }
        [Required]
        [ForeignKey("AspNetUsers")]
        public  int UserId { get; set; }
        [ForeignKey("books")]
        public  int Book_id { get; set; }

        [Display(Name = "Created date")]
        public DateTime Created_at { get; set; }

        public virtual books books { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
    
}