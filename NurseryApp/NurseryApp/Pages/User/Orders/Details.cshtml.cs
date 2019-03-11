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
using NurseryApp.Models.ViewModel;

namespace NurseryApp.Pages.User.Orders
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICheckout _context;
        private readonly ICheckoutProduct _checkoutProduce;

        /// <summary>
        /// Constructor method that brings in services to be used by the order Details page
        /// </summary>
        /// <param name="userManager">UserManager service from Identity Framework</param>
        /// <param name="context">Checkout interface</param>
        /// <param name="checkoutProduct">CheckoutProduct interface</param>
        public DetailsModel(UserManager<ApplicationUser> userManager, ICheckout context, ICheckoutProduct checkoutProduct)
        {
            _userManager = userManager;
            _context = context;
            _checkoutProduce = checkoutProduct;
        }

        [FromRoute]
        public int ID { get; set; }
        public List<BasketProductViewModel> Checkout { get; set; }

        /// <summary>
        /// Provides the Details page with a Checkout object matching the current user and ID from the route
        /// </summary>
        /// <returns>Checkout object</returns>
        public async Task OnGet()
        {
            string userEmail = User.Identity.Name;
            Checkout checkout = await _context.GetCheckoutByUserId(userEmail, ID);
            Checkout = await _checkoutProduce.GetCheckout(ID);
            foreach (var item in Checkout)
            {
                item.ProductTotal = item.Quantity * item.Price;
                item.Total = checkout.Total;
            }


        }
    }
}