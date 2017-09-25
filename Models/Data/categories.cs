namespace ZHYR_Library.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class categories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categories()
        {
            books = new HashSet<books>();
        }

        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string category_name { get; set; }

        [StringLength(1000)]
        [Display(Name = "Category About")]
        public string category_about { get; set; }

        [Display(Name="Image") ,StringLength(256)]
        public string image { get; set; }

        [Display(Name = "Created date")]
        [Column(TypeName = "datetime2")]
        public DateTime Created_at { get; set; }
        [Display(Name = "Updated date")]
        public DateTime? Updated_at { get; set; }
        [Display(Name = "Deleted date")]
        public DateTime? Deleted_at { get; set; }

        [Required]
        [Display(Name = "Shared By")]
        public int UserId { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<books> books { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
