using Microsoft.EntityFrameworkCore;
using NurseryApp.Data;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Services
{
    public class BasketProductService : IBasketProduct
    {
        private readonly NurseryDbContext _context;

        public BasketProductService(NurseryDbContext context, ApplicationDbContext appContext)
        {
            _context = context;
        }
        public async Task AddBasketProduct(BasketProduct basketProduct)
        {
            _context.BasketProducts.Add(basketProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBasketProductByID(string userID, int productID )
        {
            BasketProduct basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp => bp.UserID == userID && bp.ProductID == productID);
            _context.BasketProducts.Remove(basketProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BasketProduct>> GetBasket(string userID)
        {
            IEnumerable<BasketProduct> list = await _context.BasketProducts.ToListAsync();
            return list.Where(bp => bp.UserID == userID).ToList<BasketProduct>();
        }

        public async Task<BasketProduct> GetBasketProductByID(string userID, int productID)
        {
            BasketProduct basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp => bp.UserID == userID && bp.ProductID == productID);
            return basketProduct;
        }

        public async Task UpdateQuantity(BasketProduct basketProduct)
        {
            _context.BasketProducts.Update(basketProduct);
            await _context.SaveChangesAsync();

        }
    }
}
