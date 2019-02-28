using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    public interface IBasket
    {
        Task CreateBasket(Basket basket);

        Task UpdateBasket(Basket basket);
    }
}
