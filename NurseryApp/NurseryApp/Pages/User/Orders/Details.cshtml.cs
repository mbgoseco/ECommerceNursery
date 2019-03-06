using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;

namespace NurseryApp.Pages.User.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICheckout _context;

        public DetailsModel(UserManager<ApplicationUser> userManager, ICheckout context)
        {
            _userManager = userManager;
            _context = context;
        }
        [FromRoute]
        public int ID { get; set; }
        public Checkout Checkout { get; set; }
        public async Task OnGet()
        {
            string userEmail = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userEmail);
            Checkout = await _context.GetCheckoutByUserId(user.Id, ID);
        }
    }
}