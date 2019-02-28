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
    public class CheckoutProductService : ICheckoutProduct
    {
        private readonly NurseryDbContext _context;

        public CheckoutProductService(NurseryDbContext context)
        {
            _context = context;
        }

        public async Task AddCheckoutProduct(int id, int quantity, int checkoutID)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
            CheckoutProduct checkoutProduct = new CheckoutProduct
            {
                Product = product,
                ProductID = product.ID,
                Quantity = quantity,
                CheckoutID = checkoutID
            };
            _context.CheckoutProducts.Add(checkoutProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCheckoutProductByID(int checkoutID, int productID )
        {
            CheckoutProduct checkoutProduct = await _context.CheckoutProducts.FirstOrDefaultAsync(cp => cp.CheckoutID == checkoutID && cp.ProductID == productID);
            _context.CheckoutProducts.Remove(checkoutProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BasketProductViewModel>> GetCheckout(int checkoutID)
        {
            IEnumerable<CheckoutProduct> allProducts1 = await _context.CheckoutProducts.ToListAsync();
            IEnumerable<CheckoutProduct> allProducts = allProducts1.Where(p => p.CheckoutID == checkoutID);
            List<BasketProductViewModel> list = new List<BasketProductViewModel>();
            foreach (var item in allProducts)
            {
                if(item.CheckoutID == checkoutID)
                {
                    BasketProductViewModel bpvm = new BasketProductViewModel();
                    Product prd = _context.Products.FirstOrDefault(p => p.ID == item.ProductID);
                    bpvm.ProductID = item.ProductID;
                    bpvm.BasketID = item.CheckoutID;
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

        public async Task<BasketProduct> GetCheckoutProductByID(int checkoutID, int productID)
        {
            BasketProduct checkoutProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp => bp.BasketID == checkoutID && bp.ProductID == productID);
            return checkoutProduct;
        }

        public async Task UpdateQuantity(CheckoutProduct checkoutProduct)
        {
            _context.CheckoutProducts.Update(checkoutProduct);
            await _context.SaveChangesAsync();

        }
    }
}
