using BussinessEntites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<int> AddProductAsync(Product product);
        Task<string> DeleteProductAsync(int productId);
        Task<string> UpdateProductAsync(Product product);

    }
}
