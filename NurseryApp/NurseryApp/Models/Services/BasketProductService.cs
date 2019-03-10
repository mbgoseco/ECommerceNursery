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

        /// <summary>
        /// Constructor method that connects the service to the app's databases through its matching context.
        /// </summary>
        /// <param name="context">DbContext connection to the NurseryDb</param>
        public BasketProductService(NurseryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new basketProduct object and adds it to the BasketProduct table
        /// </summary>
        /// <param name="id">Primary Key value of product</param>
        /// <param name="quantity">Quantity of product</param>
        /// <param name="basketID">Composite Key value</param>
        /// <returns>New basketProduct added to table</returns>
        public async Task AddBasketProduct(int id, int quantity, int basketID)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
            BasketProduct basketProduct = new BasketProduct
            {
                Product = product,
                ProductID = product.ID,
                Quantity = quantity,
                BasketID = basketID
            };
            _context.BasketProducts.Add(basketProduct);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a basketProduct item from the table matching composite keys
        /// </summary>
        /// <param name="basketID">Composite basket key</param>
        /// <param name="productID">Composite product key</param>
        /// <returns>Product removed from basket</returns>
        public async Task DeleteBasketProductByID(int basketID, int productID )
        {
            BasketProduct basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp => bp.BasketID == basketID && bp.ProductID == productID);
            _context.BasketProducts.Remove(basketProduct);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a list of all items in the BasketProducts table
        /// </summary>
        /// <param name="basketID">Composite Key value</param>
        /// <returns>List of basket products</returns>
        public async Task<List<BasketProductViewModel>> GetBasket(int basketID)
        {
            IEnumerable<BasketProduct> allProducts1 = await _context.BasketProducts.ToListAsync();
            IEnumerable<BasketProduct> allProducts = allProducts1.Where(p => p.BasketID == basketID);
            List<BasketProductViewModel> list = new List<BasketProductViewModel>();
            decimal Total = 0;
            foreach (var item in allProducts)
            {
                if(item.BasketID == basketID)
                {
                    BasketProductViewModel bpvm = new BasketProductViewModel();
                    Product prd = _context.Products.FirstOrDefault(p => p.ID == item.ProductID);
                    bpvm.ProductID = item.ProductID;
                    bpvm.BasketID = item.BasketID;
                    bpvm.Quantity = item.Quantity;
                    bpvm.Name = prd.Name;
                    bpvm.Type = prd.Type;
                    bpvm.Description = prd.Description;
                    bpvm.Price = prd.Price;
                    bpvm.Sku = prd.Sku;
                    bpvm.Bulk = prd.Bulk;
                    bpvm.ProductTotal = (prd.Price * item.Quantity);
                    Total += bpvm.ProductTotal;                    
                    list.Add(bpvm);
                }
                foreach (var product in list)
                {
                    product.Total = Total;
                }
            }
            return list;
        }

        /// <summary>
        /// Gets a specific BasketProduct item matching the composite keys
        /// </summary>
        /// <param name="basketID">Composite basket key</param>
        /// <param name="productID">Composite product key</param>
        /// <returns>Matching BasketProduct item</returns>
        public async Task<BasketProduct> GetBasketProductByID(int basketID, int productID)
        {
            BasketProduct basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp => bp.BasketID == basketID && bp.ProductID == productID);
            return basketProduct;
        }

        /// <summary>
        /// Updates a BasketProduct item with new basketProduct properties
        /// </summary>
        /// <param name="basketProduct">basketProduct object with new properties</param>
        /// <returns>Updated item</returns>
        public async Task UpdateQuantity(BasketProduct basketProduct)
        {
            _context.BasketProducts.Update(basketProduct);
            await _context.SaveChangesAsync();

        }
    }
}
