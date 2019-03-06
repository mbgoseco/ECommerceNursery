using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;

namespace NurseryApp.Pages.User.Orders
{
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
            var user = await _userManager.FindByEmailAsync(userEmail);
            Checkout checkout = await _context.GetCheckoutByUserId(user.Id, ID);
            Checkout = await _checkoutProduce.GetCheckout(ID);

        }
    }
}