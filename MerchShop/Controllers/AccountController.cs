using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MerchShop.Data.EFContext;
using MerchShop.Data.Models;
using MerchShop.Models;
using MerchShop.Services;
using MerchShop.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MerchShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly EFDbContext _context;

        public AccountController(UserManager<DbUser> userManager, SignInManager<DbUser> signInManager, EFDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserProfile userProfile = new UserProfile
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegistrationDate = DateTime.Now,
                    Image = null
                };
                DbUser user = new DbUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    UserProfile = userProfile
                };

                var rolename = "User"; 
                var result = await _userManager.CreateAsync(user, model.Password);
                result = _userManager.AddToRoleAsync(user, rolename).Result;
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "This e-mail isn't registered");
                return View();
            }
            var result = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Password", "Wrong password!");
                return View();
            }
            await _signInManager.SignInAsync(user, isPersistent: true);
            await Authenticate(model.Email);
            var userInfo = new UserInfo()
            {
                UserId = user.Id,
                Email = user.Email
            };
            HttpContext.Session.SetString("SessionUserData", JsonConvert.SerializeObject(userInfo));
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login", "Account");
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "This e-mail isn't registered");
                    return View(model);
                }
                EmailService emailService = new EmailService(); 
                string url = "https://localhost:44379/Account/ChangePassword/" + user.Id;
                await emailService.SendEmailAsync(model.Email, "Forgot Password",
                    $"Dear user," +
                    $"<br/>" +
                    $"To change the password, follow the link below" +
                    $"<br/>" +
                    $"<a href='{url}'>Change password</a>");

            };
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [Route("Account/ChangePassword/{id}")]
        public IActionResult ChangePassword(string id)
        {
            return View();
        }

        [HttpPost]
        [Route("Account/ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model, string id)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    ModelState.AddModelError("", "This user isn't registered");
                    return View(model);
                }
                var hashPassword = _userManager.PasswordHasher.HashPassword(user, model.Password);
                user.PasswordHash = hashPassword;
                var result = await _userManager.UpdateAsync(user);

            };
            return RedirectToAction("Login", "Account");
        }


    }
}