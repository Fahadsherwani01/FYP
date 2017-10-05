using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FYP.Models
{
    public partial class User
    {
        public int id { get; set; }
        public string ProfilePic { get; set; }
        
        public string MdId { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gander")]
        public string Gander { get; set; }
        [Required]
      
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Admin { get; set; }
    }
}
