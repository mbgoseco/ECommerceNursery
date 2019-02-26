using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryApp.Data;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class BasketProductController : Controller
    {
        private readonly IBasketProduct _context;


        public BasketProductController(IBasketProduct context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userID = User.Claims.First(name => name.Type == "id").Value;

            var products = await _context.GetBasket(userID);

            return View(products);
        }
    }
}
