using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NurseryApp.Models;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _UserManager;
        private SignInManager<ApplicationUser> _SignInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    Birthday = rvm.Birthday
                };

                var result = await _UserManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    await _SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(rvm);
        }
    }
}
