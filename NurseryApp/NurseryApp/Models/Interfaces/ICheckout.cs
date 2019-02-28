using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    public interface ICheckout
    {
        Task CreateCheckoutAsync(Checkout checkout);

        Task UpdateCheckoutAsync(Checkout checkout);

        Task<Basket> GetCheckoutByUserId(string userID);
    }
}
