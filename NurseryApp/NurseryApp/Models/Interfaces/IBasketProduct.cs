using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    public interface IBasketProduct
    {

        Task AddBasketProduct(int id, int quantity, int basketID);

        Task<List<BasketProductViewModel>> GetBasket(int basketID);

        Task<BasketProduct> GetBasketProductByID(int basketID, int productID);

        Task UpdateQuantity(BasketProduct basketProduct);

        Task DeleteBasketProductByID(int basketID, int productID);
    }
}
