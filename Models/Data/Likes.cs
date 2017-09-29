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
        public int UserId { get; set; }
        [ForeignKey("books")]
        public int? Book_id { get; set; }
        [ForeignKey("comments")]
        public int? comment_Id { get; set; }
        [ForeignKey("posts")]
        public int? post_id { get; set; }
        [ForeignKey("replayes")]
        public int? Replay_Id { get; set; }

        [Display(Name = "Created date")]
        public DateTime Created_at { get; set; }

        public virtual books books { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Post posts { get; set; }
        public virtual comments comments { get; set; }
        public virtual Replayes replayes { get; set; }
    }
    
}