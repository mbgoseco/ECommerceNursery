using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models;

namespace NurseryApp.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class DashboardModel : PageModel
    {
        private readonly ICheckout _checkout;

        /// <summary>
        /// Constructor method that brings in services to be used by the Dashboard page
        /// </summary>
        /// <param name="checkout">Checkout interface</param>
        public DashboardModel(ICheckout checkout)
        {
            _checkout = checkout;
        }
        
        [FromRoute]
        public List<Checkout> Orders { get; set; }

        /// <summary>
        /// Provides the Dashboard page with a list of the last 10 Orders from all users
        /// </summary>
        /// <returns>List of orders</returns>
        public async Task OnGet()
        {
            Orders = await _checkout.GetLastTenCheckouts();
        }
    }
}