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

        public Basket(IBasketProduct context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userID = UserClaimsPrincipal.Claims.First(name => name.Type == "id").Value;

            var products = await _context.GetBasket(userID);
            return View(products);
        }
    }
}
