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

        public DashboardModel(ICheckout checkout)
        {
            _checkout = checkout;
        }

        [FromRoute]
        public List<Checkout> Orders { get; set; }

        public async Task OnGet()
        {
            Orders = await _checkout.GetLastTenCheckouts();
        }
    }
}