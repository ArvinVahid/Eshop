using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Eshop.Core.Entities
{
    public class User : BaseEntity<int>
    {

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }
        
        [Display(Name = "تاریخ ایجاد")]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }


        public ICollection<Order> Orders { get; set; }
    }
}
