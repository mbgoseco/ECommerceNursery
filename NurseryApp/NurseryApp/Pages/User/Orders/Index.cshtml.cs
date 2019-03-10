using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;

namespace NurseryApp.Pages.User.Orders
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICheckout _context;

        public IndexModel(UserManager<ApplicationUser> userManager, ICheckout context)
        {
            _userManager = userManager;
            _context = context;
        }

        public List<Checkout> Checkouts { get; set; }

        public async Task OnGet()
        {
            string userEmail = User.Identity.Name;
            Checkouts = await _context.GetLastFiveCheckouts(userEmail);
        }
    }
}