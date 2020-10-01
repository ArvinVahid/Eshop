using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;

namespace Eshop.Core.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {} خود را وارد کنید")]
        [MaxLength(250)]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {} خود را وارد کنید")]
        [MaxLength(16,ErrorMessage = "{} نمیتواند بیشتر از 16 کلمه باشد")]
        public string Password { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime RegisterDate { get; set; }
        public bool IsAdmin { get; set; }


        public List<Order> Orders { get; set; }
    }
}
