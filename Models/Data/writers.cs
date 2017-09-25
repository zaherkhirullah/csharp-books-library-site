namespace ZHYR_Library.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class writers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public writers()
        {
            books = new HashSet<books>();
        }

        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Author Name"), StringLength(50)]
        public string author_name { get; set; }
        public string author_about { get; set; }
        [Display(Name = "Author Image"), StringLength(256)]
        public string image { get; set; }
        [Display(Name = "Shared By")]
        public int UserId { get; set; }

        [Display(Name = "Created date")]
        [Column(TypeName = "datetime2")]
        public DateTime Created_at { get; set; }
        [Display(Name = "Updated date")]
        public DateTime? Updated_at { get; set; }
        [Display(Name = "Deleted date")]
        public DateTime? Deleted_at { get; set; }
        [Display(Name = "Birth date")]
        public DateTime? birth_date { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<books> books { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
