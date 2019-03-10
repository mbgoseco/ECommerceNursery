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

        /// <summary>
        /// Constructor method that brings in services to be used by the order Details page
        /// </summary>
        /// <param name="userManager">UserManager service from Identity Framework</param>
        /// <param name="context">Checkout interface</param>
        public IndexModel(UserManager<ApplicationUser> userManager, ICheckout context)
        {
            _userManager = userManager;
            _context = context;
        }

        public List<Checkout> Checkouts { get; set; }

        /// <summary>
        /// Provides the order Index page with a list of current user's last 5 orders
        /// </summary>
        /// <returns>List of user's last 5 orders</returns>
        public async Task OnGet()
        {
            string userEmail = User.Identity.Name;
            Checkouts = await _context.GetLastFiveCheckouts(userEmail);
        }
    }
}