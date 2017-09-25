using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZHYR_Library.Models.Data
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string massege { get; set; }
        public DateTime Created_at { get; set; }
    }
}