using Microsoft.AspNetCore.Mvc;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShop _context;

        public ShopController(IShop context)
        {
            _context = context;
        }

        /// <summary>
        /// Gives the shopping view page a list of all products in the nursery DB
        /// </summary>
        /// <returns>View of shopping page with all products</returns>
        public async Task<IActionResult> Shop()
        {
            return View(await _context.GetProducts());
        }

        /// <summary>
        /// Takes user to the details view of a specific item from the DB
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <returns>Details view of the selected product</returns>
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
