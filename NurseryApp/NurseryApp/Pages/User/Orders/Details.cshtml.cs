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

        public DetailsModel(UserManager<ApplicationUser> userManager, ICheckout context, ICheckoutProduct checkoutProduct)
        {
            _userManager = userManager;
            _context = context;
            _checkoutProduce = checkoutProduct;
        }
        [FromRoute]
        public int ID { get; set; }
        public List<BasketProductViewModel> Checkout { get; set; }
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