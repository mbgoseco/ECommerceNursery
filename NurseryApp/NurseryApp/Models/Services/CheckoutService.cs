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
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Constructor method that connects the service to the app's databases through its matching context.
        /// </summary>
        /// <param name="userManager">UserManager service from Identity Framework</param>
        /// <param name="context">DbContext connection to the NurseryDb</param>
        public CheckoutService(UserManager<ApplicationUser> userManager, NurseryDbContext context)
        {
            _context = context;
            _userManager = userManager;
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

        /// <summary>
        /// Gets the 5 most recent orders of the current user from the checkout table and returns them as a list.
        /// </summary>
        /// <param name="userID">Username which is their email</param>
        /// <returns>List of user's 5 most recent orders</returns>
        public async Task<List<Checkout>> GetLastFiveCheckouts(string userID)
        {
            var checkouts = await _context.Checkouts.ToListAsync();
            var userCheckouts = checkouts.Where(c => c.UserID == userID);
            var topFive = userCheckouts.Reverse().Take(5).ToList();
            return topFive;

        }

        /// <summary>
        /// Gets the 10 most recent orders of all users from the checkout table and returns them as a list.
        /// </summary>
        /// <returns>List of 10 most recent orders of all users</returns>
        public async Task<List<Checkout>> GetLastTenCheckouts()
        {
            var checkouts = await _context.Checkouts.ToListAsync();
            var lastTenCheckouts = checkouts.OrderByDescending(c => c.ID).Take(10).ToList();
            return lastTenCheckouts;
        }
    }
}
