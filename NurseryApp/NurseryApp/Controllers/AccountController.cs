using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _UserManager;
        private SignInManager<ApplicationUser> _SignInManager;
        private IConfiguration _context;
        private IBasket _basket;
        private IEmailSender _emailSender;

        /// <summary>
        /// Constructor method that brings in services to be used by the AccountController
        /// </summary>
        /// <param name="userManager">UserManager service from Identity Framework</param>
        /// <param name="signInManager">SignInManager service from Identity Framework</param>
        /// <param name="context">Configuration strings from user secrets</param>
        /// <param name="basket">Basket interface</param>
        /// <param name="emailsender">Emailsender interface</param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration context, IBasket basket, IEmailSender emailsender)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _context = context;
            _basket = basket;
            _emailSender = emailsender;
        }

        /// <summary>
        /// Displays the user registration page where users can create an account
        /// </summary>
        /// <returns>User registration page</returns>
        [HttpGet]
        public IActionResult Register() => View();

        /// <summary>
        /// Take the data from the registration page form, create a new user object, assign the new user claims and roles, add it to the user DB, and return to the home page.
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
                    await _basket.CreateBasketAsync(basket);
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim landscaperClaim = new Claim("Landscape", $"{user.Landscaper}");

                    Claim idClaim = new Claim("id", $"{user.Id}");

                    List<Claim> claims = new List<Claim> { fullNameClaim, emailClaim, birthdayClaim, landscaperClaim, idClaim };
                
                    await _UserManager.AddClaimsAsync(user, claims);

                    if(user.Email.ToUpper() == "95COSTELLO@GMAIL.COM" || user.Email.ToUpper() == "mbgoseco@gmail.com".ToUpper() || user.Email.ToUpper() == "AMANDA@CODEFELLOWS.COM")
                    {
                        await _UserManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    }



                    await _SignInManager.SignInAsync(user, isPersistent: false);

                    if (await _UserManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                    {
                        return RedirectToPage("/Admin/Dashboard");
                    };

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
                    var user = await _UserManager.FindByEmailAsync(lvm.Email); 
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<h1>Welcome to Binary Tree Nursery<h1>");
                    sb.AppendLine("<h2>We're glad you're here<h2>");
                    await _emailSender.SendEmailAsync(lvm.Email, "Thanks for Signing In!", sb.ToString());

                    if (await _UserManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                    {
                        return RedirectToPage("/Admin/Dashboard");
                    };
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Username and/or Password is incorrect.");

            return View(lvm);
        }

        /// <summary>
        /// Logs a user out
        /// </summary>
        /// <returns>Main page</returns>
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Directs a user to the external login page of their choice
        /// </summary>
        /// <param name="provider">Name of third party authenticator</param>
        /// <returns>Challenge result of given provider and properties</returns>
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(properties, provider);
        }

        /// <summary>
        /// Requests OAuth token if login callback returns without errors
        /// </summary>
        /// <param name="error">Incoming error message if exists</param>
        /// <returns>Home page view with user logged in if successful</returns>
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
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<h1>Welcome to Binary Tree Nursery<h1>");
                sb.AppendLine("<h2>We're glad you're here<h2>");
                string userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
                await _emailSender.SendEmailAsync(userEmail, "Thanks for Signing In!", sb.ToString());

                var user = await _UserManager.FindByEmailAsync(userEmail);
                if (await _UserManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                {
                    return RedirectToPage("/Admin/Dashboard");
                };
                return RedirectToAction("Index", "Home");
            }
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            return View("ExternalLogin", new ExternalLoginViewModel { Email = email });

        }

        /// <summary>
        /// Registers a new user with their their party user properties.
        /// </summary>
        /// <param name="elvm">External Login View Model</param>
        /// <returns>Home page view with user logged in if successful</returns>
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
                    await _basket.CreateBasketAsync(basket);
                    


                    result = await _UserManager.AddLoginAsync(user, info);

                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim landscaperClaim = new Claim("Landscape", $"{user.Landscaper}");

                    Claim idClaim = new Claim("id", $"{user.Id}");

                    List<Claim> claims = new List<Claim> { fullNameClaim, emailClaim, birthdayClaim, landscaperClaim, idClaim };

                    await _UserManager.AddClaimsAsync(user, claims);
                    if (user.Email.ToUpper() == "95COSTELLO@GMAIL.COM" || user.Email.ToUpper() == "mbgoseco@gmail.com".ToUpper() || user.Email.ToUpper() == "AMANDA@CODEFELLOWS.COM")
                    {
                        await _UserManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    }


                    if (result.Succeeded)
                    {
                        await _SignInManager.SignInAsync(user, isPersistent: false);
                        if (await _UserManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                        {
                            return RedirectToPage("/Admin/Dashboard");
                        };
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View("ExternalLogin");
        }
    }
}
