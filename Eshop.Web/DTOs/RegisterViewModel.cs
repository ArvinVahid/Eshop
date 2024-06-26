﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Core.Entities;

namespace Eshop.Web.DTOs
{
    public class RegisterViewModel
    {
        [MaxLength(300)]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(16)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(16)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "کلمه عبور با تکرار کلمه عبور مطابقت ندارد")]
        [Display(Name = "تکرار کلمه عبور")]
        public string RePassword { get; set; }
    }
}
