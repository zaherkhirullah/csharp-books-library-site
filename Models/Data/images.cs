namespace ZHYR_Library.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class images
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Image Name")]
        public string image_name { get; set; }

        [StringLength(1000)]
        [Display(Name = "Image About")]
        public string image_about { get; set; }
        [Required]
        [Display(Name = "Image"), StringLength(256)]
        public string image { get; set;
        }
        [Display(Name = "Created date")]
        [Column(TypeName = "datetime2")]
        public DateTime Created_at { get; set; }
        [Display(Name = "Updated date")]
        public DateTime? Updated_at { get; set; }
        [Display(Name = "Deleted date")]
        public DateTime? Deleted_at { get; set; }

        [Required]
        [Display(Name = "Shared By ")]
        public int UserId { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
