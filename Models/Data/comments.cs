namespace ZHYR_Library.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comments
    {
        [Key]
        public int id { get; set; }

        [Required ,StringLength(1000)]
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
         [ForeignKey("books")]
        public int? BookId { get; set; }

        [ForeignKey("posts")]
        public int? post_id { get; set; }

        [Required]
        [Display(Name = "Shared By")]
        public int UserId { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual books books { get; set; }
        public virtual Post posts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Likes> Likes { get; set; }
    }
}
