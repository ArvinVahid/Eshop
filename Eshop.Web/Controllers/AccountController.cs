using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Threading;
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
        public async Task<IActionResult> Register(RegisterViewModel register, CancellationToken cancellationToken)
        {
            ViewBag.Email = EmailCleaner.CleanedEmail(register.Email);
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (await _userServices.IsExistByEmail(register.Email, cancellationToken))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت نام کرده است");
                return View(register);
            }


            var userDTO = _mapper.Map<User>(register);
            await _userServices.AddUser(userDTO, cancellationToken);
            await _userServices.SaveChangeAsync(cancellationToken);
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
        public async  Task<IActionResult> Login(LoginViewModel login, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = await _userServices.LoginUser(login.Email, login.Password, cancellationToken);
            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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

            await HttpContext.SignInAsync(principal, properties);

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
