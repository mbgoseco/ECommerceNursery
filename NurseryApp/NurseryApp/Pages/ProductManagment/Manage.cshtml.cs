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
    public class ManageModel : PageModel
    {
        private readonly IInventory _context;

        /// <summary>
        /// Constructor method that brings in services to be used by the Manage page
        /// </summary>
        /// <param name="checkout">Checkout interface</param>
        public ManageModel(IInventory context)
        {
            _context = context;
        }

        [FromRoute]
        public int? ID { get; set; }
        public Product Product { get; set; }

        /// <summary>
        /// Provides the Manage page with a product matching the ID from the route or an instance of a new product to create
        /// </summary>
        /// <returns>Selected or new product object</returns>
        public async Task OnGet()
        {
            Product = await _context.GetProductByID(ID.GetValueOrDefault()) ?? new Product();              
        }

        /// <summary>
        /// Updates data for existing product, or adds a new product to the Product table if the ID does not exist
        /// </summary>
        /// <param name="Product">Product object</param>
        /// <returns>Redirect to Index page</returns>
        public async Task<IActionResult> OnPost(Product Product)
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

            return RedirectToPage("Index");
        }

        /// <summary>
        /// Deletes a selected product matching the ID value
        /// </summary>
        /// <returns>Redirect to Index page</returns>
        public async Task<IActionResult> OnPostDelete()
        {
            await _context.DeleteProductByID(ID.Value);
            return RedirectToPage("Index");
        }
    }
}