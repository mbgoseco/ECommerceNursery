using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    public interface IInventory
    {
        Task CreateProduct(Product product);

        Task<List<Product>> GetAllProducts();

        Task<Product> GetProductByID(int id);

        Task Update(Product product);

        Task DeleteProductByID(int id);
    }
}
