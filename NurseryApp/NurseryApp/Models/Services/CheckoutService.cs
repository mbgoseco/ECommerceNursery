using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NurseryApp.Data;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Services
{
    public class CheckoutService : ICheckout
    {
        private readonly NurseryDbContext _context;

        public CheckoutService(NurseryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a checkout order to the table
        /// </summary>
        /// <param name="checkout">Checkout object</param>
        /// <returns>Checkout order added to table</returns>
        public async Task CreateCheckoutAsync(Checkout checkout)
        {
            _context.Checkouts.Add(checkout);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a checkout order belonging to the matching userID
        /// </summary>
        /// <param name="userID">Primary Key value</param>
        /// <returns>Result of checkout query</returns>
        public async Task<Checkout> GetCheckoutByUserId(string userID, int id)
        {
            return await _context.Checkouts.FirstOrDefaultAsync(c => c.UserID == userID && c.ID == id);

        }

        /// <summary>
        /// Updates a checkout order with new parameters
        /// </summary>
        /// <param name="checkout">Checkout object</param>
        /// <returns>Updated checkout order</returns>
        public async Task UpdateCheckoutAsync(Checkout checkout)
        {
            _context.Checkouts.Update(checkout);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Checkout>> GetLastFiveCheckouts(string userID)
        {
            var checkouts = await _context.Checkouts.ToListAsync();
            var userCheckouts = checkouts.Where(c => c.UserID == userID);
            var topFive = userCheckouts.Reverse().Take(5).ToList();
            return topFive;

        }

        public async Task<List<Checkout>> GetLastTenCheckouts()
        {
            var checkouts = await _context.Checkouts.ToListAsync();
            var lastTenCheckouts = checkouts.OrderByDescending(c => c.ID).Take(10).ToList();
            return lastTenCheckouts;
        }
    }
}
