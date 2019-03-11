using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;

namespace NurseryApp.Pages.ProductManagment
{
    [Authorize(Policy = "AdminOnly")]
    public class IndexModel : PageModel
    {
        private readonly IInventory _context;

        /// <summary>
        /// Constructor method that brings in services to be used by the ProductManagement's Index page
        /// </summary>
        /// <param name="context">Inventory interface</param>
        public IndexModel(IInventory context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; }

        /// <summary>
        /// Provides the Index page with a list of all Products in the store's inventory
        /// </summary>
        /// <returns>List of Products</returns>
        public async Task OnGet()
        {
            Products = await _context.GetAllProducts();
        }
    }
}