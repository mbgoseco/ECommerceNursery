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
    public class BasketController : IBasket
    {
        private readonly NurseryDbContext _context;

        public BasketController(NurseryDbContext context)
        {
            _context = context;
        }
        public async Task CreateBasketAsync(Basket basket)
        {
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBasketAsync(Basket basket)
        {
            _context.Baskets.Update(basket);
            await _context.SaveChangesAsync();
        }

        public async Task<Basket> GetBasketByUserId(string userID)
        {
            Basket basket = await _context.Baskets.FirstOrDefaultAsync(b => b.UserID == userID);
            return basket;
        }
    }
}
