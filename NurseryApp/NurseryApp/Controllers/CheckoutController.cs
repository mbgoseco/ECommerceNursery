using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckout _context;
        private readonly IBasket _basketcontext;
        private readonly IBasketProduct _basketProduct;
        private readonly ICheckoutProduct _checkoutProduct;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutController(UserManager<ApplicationUser> userManager, ICheckout context, IBasketProduct basketProduct, IBasket basketcontext, ICheckoutProduct checkoutProduct)
        {
            _context = context;
            _userManager = userManager;
            _basketcontext = basketcontext;
            _basketProduct = basketProduct;
            _checkoutProduct = checkoutProduct;
        }

        public async Task<IActionResult> Receipt()
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            string userID = userRaw.Id;
            
            Basket basket = await _basketcontext.GetBasketByUserId(userID);
            List<BasketProductViewModel> basketProducts =  await _basketProduct.GetBasket(basket.ID);

            Checkout checkout = new Checkout();
            checkout.UserID = userID;
            await _context.CreateCheckoutAsync(checkout);
            foreach (var bp in basketProducts)
            {
                await _checkoutProduct.AddCheckoutProduct(bp.ProductID, bp.Quantity, checkout.ID);
                bp.BasketID = checkout.ID;
            }

            return View(basketProducts);
        }
    }
}
