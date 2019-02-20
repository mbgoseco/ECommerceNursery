using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    public interface IInventory
    {
        Task CreateProduct();

        Task<List<Product>> GetAllProducts();

        Task<Product> GetProductByID();

        Task Update();

        Task DeleteProductByID();
    }
}
