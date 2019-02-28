using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    public interface IBasket
    {
        Task CreateBasketAsync(Basket basket);

        Task UpdateBasketAsync(Basket basket);

        Task<Basket> GetBasketByUserId(string userID);
    }
}
