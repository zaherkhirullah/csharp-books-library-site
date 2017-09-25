using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZHYR_Library.Models.Data
{
    public class Favorites
    {
        [Key]
        public int Id { get; set; }
        public bool Favorited { get; set; }

        [Required]
        [Display(Name = "favorited By")]
        public int User_Id { get; set; }
        public virtual AspNetUsers User { get; set; }


        [Display(Name = "Created date")]
        public DateTime Created_at { get; set; }

        //public virtual ICollection<books> books { get; set; }
 
    }
    
}