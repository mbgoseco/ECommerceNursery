using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;

namespace NurseryApp.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly ICheckout _checkout;
        private readonly ICheckoutProduct _checkoutProduct;

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

        public async Task OnGetAsync()
        {
            Order = await _checkout.GetCheckoutByUserId(UserID, ID);
        }
    }
}