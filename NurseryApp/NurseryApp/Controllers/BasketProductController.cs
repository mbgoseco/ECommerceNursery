using Microsoft.AspNetCore.Mvc;
using NurseryApp.Models.Interfaces;
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
        public IActionResult Index()
        {
            return View();
        }


    }
}
