using AspnetRun.Application.Dtos;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class ProductAppService : AspnetRunAppService<Product, ProductDto>, IProductAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductAppService(IAsyncRepository<Product> repository, IAppLogger<Product> logger, IProductRepository productRepository)
            : base(repository, logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<ProductDto>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }

        public async Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId)
        {
            var productList = await _productRepository.GetProductByCategoryAsync(categoryId);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }

        public async Task<IEnumerable<ProductDto>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }

        public async Task Insert(ProductDto product)
        {
            // Validate(product);
            //this.ValidateProduct(productId, product);
            _logger.LogInformation($"Product successfully added.");

            // validation should be handled in here 
        }

        private void ValidateProduct(Guid productId, Product product)
        {
            if (product == null)
                throw new ApplicationException(String.Format("Product was not found with this Id: {0}", productId));
        }
    }
}
