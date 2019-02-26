using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryApp.Data;
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
        private readonly ApplicationDbContext _appContext;

        public BasketProductController(IBasketProduct context, ApplicationDbContext appContext)
        {
            _context = context;
            _appContext = appContext;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {   var user = User.Claims.
            return View();
        }
    }
}
