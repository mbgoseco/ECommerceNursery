using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NurseryApp.Models;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _UserManager;
        private SignInManager<ApplicationUser> _SignInManager;
        private IConfiguration _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration context)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _context = context;
        }

        /// <summary>
        /// Displays the user registration page where users can create an account
        /// </summary>
        /// <returns>User registration page</returns>
        [HttpGet]
        public IActionResult Register() => View();

        /// <summary>
        /// Take the data from the registration page form, create a new user object, add it to the user DB, and return to the home page.
        /// </summary>
        /// <param name="rvm">Register View Model data from form</param>
        /// <returns>New user object and redirect to home page</returns>
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
                    Birthday = rvm.Birthday,
                    Landscaper = rvm.Landscaper
                };

                var result = await _UserManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    Basket basket = new Basket();
                    basket.UserID = user.Id;
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim landscaperClaim = new Claim("Landscape", $"{user.Landscaper}");

                    Claim idClaim = new Claim("id", $"{user.Id}");

                    List<Claim> claims = new List<Claim> { fullNameClaim, emailClaim, birthdayClaim, landscaperClaim, idClaim };

                    await _UserManager.AddClaimsAsync(user, claims);

                    await _SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(rvm);
        }

        /// <summary>
        /// Displays the page for users to login
        /// </summary>
        /// <returns>Login view</returns>
        [HttpGet]
        public IActionResult Login() => View();

        /// <summary>
        /// Takes in the data from the login page and checks if the credentials provided are valid. If valid, the user is signed in and redirected to the home page. If not, they are given an error message and kept on the login page.
        /// </summary>
        /// <param name="lvm">Login View Model data from login form</param>
        /// <returns>User logged in at home page or error message</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _SignInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Username and/or Password is incorrect.");

            return View(lvm);
        }

        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

       public async Task<IActionResult> ExternalLoginCallback(string error = null)
        {
            if (error != null)
            {
                TempData["Error"] = "Error with Proivder";
                return RedirectToAction("Login");
            }
            var info = await _SignInManager.GetExternalLoginInfoAsync();

            if(info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            return View("ExternalLogin", new ExternalLoginViewModel { Email = email });

        }

        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel elvm)
        {
            if (ModelState.IsValid)
            {
                var info = await _SignInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    TempData["Error"] = "Error loading information";
                }

                var user = new ApplicationUser { UserName = elvm.Email, Email = elvm.Email, Birthday = elvm.Birthday, Landscaper = elvm.Landscaper, FirstName = elvm.FirstName, LastName = elvm.LastName };
                var result = await _UserManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    Basket basket = new Basket();
                    basket.UserID = user.Id;


                    result = await _UserManager.AddLoginAsync(user, info);

                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim landscaperClaim = new Claim("Landscape", $"{user.Landscaper}");

                    Claim idClaim = new Claim("id", $"{user.Id}");

                    List<Claim> claims = new List<Claim> { fullNameClaim, emailClaim, birthdayClaim, landscaperClaim, idClaim };

                    await _UserManager.AddClaimsAsync(user, claims);


                    if (result.Succeeded)
                    {
                        await _SignInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View("ExternalLogin");
        }
    }
}
