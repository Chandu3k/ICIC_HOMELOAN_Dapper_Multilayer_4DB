using BussinessEntites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<int> AddProductAsync(ProductDto productDto);
        Task<string> DeleteProductAsync(int productId);
        Task<string> UpdateProductAsync(ProductDto productDto);
    }
}
