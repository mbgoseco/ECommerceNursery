using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NurseryApp.Data;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Services
{
    public class BasketService : IBasket
    {
        private readonly NurseryDbContext _context;

        /// <summary>
        /// Constructor method that connects the service to the app's databases through its matching context.
        /// </summary>
        /// <param name="context">DbContext connection to the NurseryDb</param>
        public BasketService(NurseryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a basket instance to the Basket table when a user registers
        /// </summary>
        /// <param name="basket">Basket object</param>
        /// <returns>New basket in table</returns>
        public async Task CreateBasketAsync(Basket basket)
        {
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the properties of the basket object
        /// </summary>
        /// <param name="basket">Basket object with new properties</param>
        /// <returns>Updated basket</returns>
        public async Task UpdateBasketAsync(Basket basket)
        {
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a basket belonging to the matching userID
        /// </summary>
        /// <param name="userID">Primary Key value</param>
        /// <returns>User's basket</returns>
        public async Task<Basket> GetBasketByUserId(string userID)
        {
            Basket basket = await _context.Baskets.FirstOrDefaultAsync(b => b.UserID == userID);
            return basket;
        }
    }
}
