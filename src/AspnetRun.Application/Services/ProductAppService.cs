using AspnetRun.Application.Dtos;
using AspnetRun.Application.Infrastructure.Mapper;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<ProductOutput>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductOutput>>(productList);
            return mapped;
        }

        public async Task<IEnumerable<ProductOutput>> GetProductByCategory(int categoryId)
        {
            var productList = await _productRepository.GetProductByCategoryAsync(categoryId);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductOutput>>(productList);
            return mapped;            
        }

        public async Task<IEnumerable<ProductOutput>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductOutput>>(productList);
            return mapped;
        }
    }
}
