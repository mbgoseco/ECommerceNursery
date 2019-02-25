using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    public interface IShop
    {
        Task<Product> GetProduct(int id);

        Task<IEnumerable<Product>> GetProducts();
    }
}
