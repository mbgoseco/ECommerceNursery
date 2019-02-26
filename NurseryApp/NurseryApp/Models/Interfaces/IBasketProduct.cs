using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    interface IBasketProduct
    {
        Task AddBasketProduct(BasketProduct basketProduct);

        Task<List<BasketProduct>> GetBasket();

        Task<BasketProduct> GetBasketProductByID(int id);

        Task UpdateQuantity(Product basketProduct);

        Task DeleteBasketProductByID(int id);
    }
}
