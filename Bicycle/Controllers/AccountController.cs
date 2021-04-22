using Bicycle.DataAccess.Identity;
using Bicycle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicycle.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            _logger.LogInformation(string.Format("ziyaretçi giriş yapıyor..."));
            var model = new LoginViewModel();
            model.ReturnUrl = returnUrl;
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("kullanıcı giriş yapıyor...");
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı ya da şifre");
                _logger.LogInformation("Geçersiz kullanıcı adı ya da şifre girildi");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("yeni kullanıcı kayıt denemesi yapıyor...");
                //IsUsernameInUse(), normalde eşsiz(unique) kullanıcı adı kontrolünü yapmaktadır.  
                //Var olan bir kullanıcı herhangi bir sebeple model içinde gelirse 
                var IsThereAnyUser = await _userManager.FindByNameAsync(model.Username);
                if (IsThereAnyUser != null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı zaten kullanımdadır.");
                    return View(model);
                }

                var user = new AppUser { UserName = model.Username};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ViewBag.Title = "Kayıt başarıyla tamamlandı.";
                    _logger.LogInformation("yeni kullanıcı kayıt işlemi başarılı");
                    return View("_Success");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                _logger.LogInformation("yeni kullanıcı kayıt işlemi başarısız");
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Kullanıcı sistemden çıkış yaptı.");
            return RedirectToAction("Index", "Home");
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUsernameInUse(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Kullanıcı adı {username} kullanımdadır.");
            }
        }
    }
}
