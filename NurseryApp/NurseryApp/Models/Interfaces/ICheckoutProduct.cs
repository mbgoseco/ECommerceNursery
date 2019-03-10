using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    public interface ICheckoutProduct
    {

        Task AddCheckoutProduct(int id, int quantity, int checkoutID);

        Task<List<BasketProductViewModel>> GetCheckout(int checkoutID);

        Task<CheckoutProduct> GetCheckoutProductByID(int checkoutID, int productID);

        Task UpdateQuantity(CheckoutProduct checkoutProduct);

        Task DeleteCheckoutProductByID(int checkoutID, int productID);
    }
}
