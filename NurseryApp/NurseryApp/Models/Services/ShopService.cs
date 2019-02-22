using Microsoft.EntityFrameworkCore;
using NurseryApp.Data;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Services
{
    public class ShopService : IShop
    {
        private readonly NurseryDbContext _context;

        public ShopService(NurseryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Finds a selected plant in the nusery DB and returns the object matching the ID
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <returns>Matching product object</returns>
        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
        }

        /// <summary>
        /// Returns a list of all product objects in the nursery DB
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
