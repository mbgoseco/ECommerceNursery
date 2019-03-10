using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryApp.Models;
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

        /// <summary>
        /// Constructor method that brings in services to be used by the ShopController
        /// </summary>
        /// <param name="context">Shop interface</param>
        public ShopController(IShop context)
        {
            _context = context;
        }

        /// <summary>
        /// Gives the shopping view page a list of all (non-bulk)products in the nursery DB
        /// </summary>
        /// <returns>View of shopping page with all (non-bulk)products</returns>
        public async Task<IActionResult> Shop()
        {
            IEnumerable<Product> products = await _context.GetProducts();
            IEnumerable<Product> results = products.Where(p => p.Bulk == false);
            return View(results);
        }

        /// <summary>
        /// Only returns a view if the user is a landscaper. Returns a view of all bulk products.
        /// </summary>
        /// <returns>View of Landscaper Shop with all bulk products</returns>
        [Authorize(Policy = "Landscaper")]
        public async Task<IActionResult> LandscaperShop()
        {
            IEnumerable<Product> bulkProducts = await _context.GetProducts();
            IEnumerable<Product> results = bulkProducts.Where(p => p.Bulk == true);
            return View(results);
        }

        /// <summary>
        /// Takes user to the details view of a specific item from the DB
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <returns>Details view of the selected product</returns>
        [HttpGet]
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
