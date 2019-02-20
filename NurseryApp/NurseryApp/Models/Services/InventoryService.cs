using Microsoft.EntityFrameworkCore;
using NurseryApp.Data;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Services
{
    public class InventoryService : IInventory
    {
        //Properties
        private readonly NurseryDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">NurseryDbContext</param>
        public InventoryService(NurseryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Task</returns>
        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a product from the Products table by ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        public async Task DeleteProductByID(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.ID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all products in the Product table
        /// </summary>
        /// <returns>A list of Products</returns>
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        /// <summary>
        /// Get a product by ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Product</returns>
        public async Task<Product> GetProductByID(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
            return product;
        }
        /// <summary>
        /// Update a product after changes have been made.
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Task</returns>
        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
