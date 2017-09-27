namespace ZHYR_Library.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class books
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Book Name")]
        public string book_name { get; set; }

        [StringLength(1000)]
        [Display(Name = "Book About")]
        public string book_about { get; set; }

        [Display(Name = "Image"), StringLength(256)]
        public string image { get; set; }

        [StringLength(256)]
        [Display(Name = "Pdf Book")]
        public string book_path { get; set; }

        [Display(Name = "Created date")]
        [Column(TypeName = "datetime2")]
        public DateTime Created_at { get; set; }
        [Display(Name = "Updated date")]
        public DateTime? Updated_at { get; set; }
        [Display(Name = "Deleted date")]
        public DateTime? Deleted_at { get; set; }
        public int Liked { get; set; }
        public int disLike { get; set; }
        public int favorited { get; set; }
        public int downloaded { get; set; }
        public int Readed { get; set; }
        [Required]
        [Display(Name = "Shared By")]
        public int UserId { get; set; }
        [Display(Name = "Writer")]
        public int author_id { get; set; }
        [Display(Name = "Category")]
        public int category_id { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual writers writers { get; set; }
        public virtual categories categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comments> comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Likes> Likes { get; set; }
      
    }
}
