using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Eshop.Core.Convertors;
using Eshop.Core.Entities;
using Eshop.Core.Services.Interfaces;
using Eshop.Web.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public AccountController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        #region Register

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            ViewBag.Email = EmailCleaner.CleanedEmail(register.Email);
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userServices.IsExistByEmail(register.Email))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
                return View(register);
            }


            var userDTO = _mapper.Map<User>(register);
            _userServices.AddUser(userDTO);
            _userServices.SaveChanges();
            return View("SuccessRegister", register);
        }

        #endregion

        #region Login

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userServices.LoginUser(login.Email, login.Password);
            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("IsAdmin", user.IsAdmin.ToString()),
                // new Claim("CodeMeli", user.Email),

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");

            #endregion

        }

        #region Logout

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        #endregion
    }
}
