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
        public IndexModel(IInventory context)
        {
            _context = context;
        }
        public List<Product> Products { get; set; }
        public async Task OnGet()
        {
            Products = await _context.GetAllProducts();
        }
    }
}