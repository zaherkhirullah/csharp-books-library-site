using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZHYR_Library.Models.Data
{
    public class Replayes
    {
        [Key]
        public int id { get; set; }
        [Required, StringLength(1000)]
        public string comment { get; set; }

        [Display(Name = "Image"), StringLength(256)]
        public string image { get; set; }

        [Display(Name = "Created date")]
        [Column(TypeName = "datetime2")]
        public DateTime Created_at { get; set; }
        [Display(Name = "Updated date")]
        public DateTime? Updated_at { get; set; }
        [Display(Name = "Deleted date")]
        public DateTime? Deleted_at { get; set; }
        [ForeignKey("comments")]
        public int comment_Id { get; set; }
        [Required]
        [Display(Name = "Shared By")]
        [ForeignKey("AspNetUsers")]
        public int UserId { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual comments comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Likes> Likes { get; set; }
    }
    
}