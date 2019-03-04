using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Components
{
    public class Basket : ViewComponent
    {
        private readonly IBasketProduct _context;
        private readonly IBasket _basket;
        private readonly UserManager<ApplicationUser> _userManager;

        public Basket(IBasketProduct context, UserManager<ApplicationUser> userManager, IBasket basket)
        {
            _context = context;
            _userManager = userManager;
            _basket = basket;
        }

        /// <summary>
        /// Invokes the component view of the user's shopping basket
        /// </summary>
        /// <returns>Component view of basket</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userEmail = User.Identity.Name;
            var userRaw = await _userManager.FindByEmailAsync(userEmail);
            string userID = userRaw.Id;
            var basket = await _basket.GetBasketByUserId(userID);

            var products = await _context.GetBasket(basket.ID);
            return View(products);
        }
    }
}
