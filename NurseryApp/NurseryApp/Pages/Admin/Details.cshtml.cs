using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;

namespace NurseryApp.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class DetailsModel : PageModel
    {
        private readonly ICheckout _checkout;
        private readonly ICheckoutProduct _checkoutProduct;

        /// <summary>
        /// Constructor method that brings in services to be used by the Details page
        /// </summary>
        /// <param name="checkout">Checkout interface</param>
        /// <param name="checkoutProduct">CheckoutProduct interface</param>
        public DetailsModel(ICheckout checkout, ICheckoutProduct checkoutProduct)
        {
            _checkout = checkout;
            _checkoutProduct = checkoutProduct;
        }

        [FromRoute]
        public string UserID { get; set; }
        [FromRoute]
        public int ID { get; set; }
        public Checkout Order { get; set; }

        /// <summary>
        /// Provides the Details page with details of a selected order
        /// </summary>
        /// <returns>Selected checkout object</returns>
        public async Task OnGetAsync()
        {
            Order = await _checkout.GetCheckoutByUserId(UserID, ID);
        }
    }
}