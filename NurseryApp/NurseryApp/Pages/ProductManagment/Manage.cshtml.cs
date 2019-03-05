using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;

namespace NurseryApp.Pages.ProductManagment
{
    public class ManageModel : PageModel
    {
        private readonly IInventory _context;
        public ManageModel(IInventory context)
        {
            _context = context;
        }

        [FromRoute]
        public int? ID { get; set; }
        public Product Product { get; set; }
        public async void OnGet()
        {
            Product = await _context.GetProductByID(ID.GetValueOrDefault()) ?? new Product();              
        }

        public async Task<IActionResult> OnPost()
        {
            var product = await _context.GetProductByID(ID.GetValueOrDefault()) ?? new Product();
            product.Name = Product.Name;
            product.Description = Product.Description;
            product.Type = Product.Type;
            product.Quantity = Product.Quantity;
            product.Sku = Product.Sku;
            product.Bulk = Product.Bulk;
            product.Img = Product.Img;

            if (ID != null)
            {
                await _context.Update(product);
            }
            else
            {
                await _context.CreateProduct(product);
            }

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _context.DeleteProductByID(ID.Value);
            return RedirectToPage("Index");
        }
    }
}