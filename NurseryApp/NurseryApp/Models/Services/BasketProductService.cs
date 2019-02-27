using Microsoft.EntityFrameworkCore;
using NurseryApp.Data;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Services
{
    public class BasketProductService : IBasketProduct
    {
        private readonly NurseryDbContext _context;

        public BasketProductService(NurseryDbContext context)
        {
            _context = context;
        }

        public async Task AddBasketProduct(int id, int quantity, string userID)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
            BasketProduct basketProduct = new BasketProduct
            {
                Product = product,
                ProductID = product.ID,
                Quantity = quantity,
                UserID = userID
            };
            _context.BasketProducts.Add(basketProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBasketProductByID(string userID, int productID )
        {
            BasketProduct basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp => bp.UserID == userID && bp.ProductID == productID);
            _context.BasketProducts.Remove(basketProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BasketProductViewModel>> GetBasket(string userID)
        {
            IEnumerable<BasketProduct> allProducts = await _context.BasketProducts.ToListAsync();
            List<BasketProductViewModel> list = new List<BasketProductViewModel>();
            foreach (var item in allProducts)
            {
                if(item.UserID == userID)
                {
                    BasketProductViewModel bpvm = new BasketProductViewModel();
                    Product prd = _context.Products.FirstOrDefault(p => p.ID == item.ProductID);
                    bpvm.ProductID = item.ProductID;
                    bpvm.UserID = item.UserID;
                    bpvm.Quantity = item.Quantity;
                    bpvm.Name = prd.Name;
                    bpvm.Type = prd.Type;
                    bpvm.Description = prd.Description;
                    bpvm.Price = prd.Price;
                    bpvm.Sku = prd.Sku;
                    bpvm.Bulk = prd.Bulk;
                    list.Add(bpvm);
                }
            }
            return list;
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
