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
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public Task DeleteProductByID()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByID()
        {
            throw new NotImplementedException();
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
