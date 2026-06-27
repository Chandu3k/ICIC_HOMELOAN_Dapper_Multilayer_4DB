using AutoMapper;
using BussinessEntites.Dtos;
using BussinessEntites.Interfaces.IRepository;
using BussinessEntites.Interfaces.IServices;
using BussinessEntites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<int> AddProductAsync(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            return await _productRepository.AddProductAsync(productEntity);

        }

        public async Task<string> DeleteProductAsync(int productId)
        {
           string result = await _productRepository.DeleteProductAsync(productId);
           return result;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var productEntities = await _productRepository.GetAllProductsAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(productEntities);
            return productDtos;

        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var productEntity = await _productRepository.GetProductByIdAsync(productId);
            return _mapper.Map<ProductDto>(productEntity);
        }

        public async Task<string> UpdateProductAsync(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            return await _productRepository.UpdateProductAsync(productEntity);
        }
    }
}
