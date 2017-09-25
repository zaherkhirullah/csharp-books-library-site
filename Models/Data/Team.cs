using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZHYR_Library.Models.Data
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Image"), StringLength(256)]
        public string image { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Content { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Phone Number"),DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string Adress { get; set; }
        public bool Gender { get; set; }
        public int Tip { get; set; }

        [Display(Name = "Created date")]
        [Column(TypeName = "datetime2")]
        public DateTime Created_at { get; set; }
        [Display(Name = "Updated date")]
        public DateTime? Updated_at { get; set; }
        [Display(Name = "Deleted date")]
        public DateTime? Deleted_at { get; set; }
    }
}