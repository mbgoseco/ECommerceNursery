using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NurseryApp.Models;

namespace NurseryApp.Pages.User.Profile
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Constructor method that brings in services to be used by the Profile page
        /// </summary>
        /// <param name="userManager">UserManager service from Identity Framework</param>
        public ProfileModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [BindProperty]
        public string NewFirstName { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Provides the Profile page with current user's profile data
        /// </summary>
        /// <returns>ApplicationUser object of current user</returns>
        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            FullName = $"{user.FirstName} {user.LastName}";
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.UserName;
        }

        /// <summary>
        /// Updates the current user's first name in the user database and claims list
        /// </summary>
        /// <returns>Redirect to user profile page</returns>
        public async Task<IActionResult> OnPostNameChange()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            Claim oldFullNameClaim = User.Claims.First(name => name.Type == "FullName");
            Claim fullNameClaim = new Claim("FullName", $"{NewFirstName} {user.LastName}");
            await _userManager.ReplaceClaimAsync(user, oldFullNameClaim, fullNameClaim);

            user.FirstName = NewFirstName;
            await _userManager.UpdateAsync(user);

            return RedirectToPage("/User/Profile/Profile");
        }

        /// <summary>
        /// Updates the current user's password in the user database
        /// </summary>
        /// <returns>Redirect to user profile page</returns>
        public async Task<IActionResult> OnPostPasswordChange()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.ChangePasswordAsync(user, OldPassword, NewPassword);

            return RedirectToPage("/User/Profile/Profile");
        }
    }
}