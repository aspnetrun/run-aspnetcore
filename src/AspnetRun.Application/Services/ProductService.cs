using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using AspnetRun.Application.Models;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Interfaces;

namespace AspnetRun.Application.Services
{
    // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, IAppLogger<ProductService> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }

        public async Task<ProductModel> GetProductById(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var mapped = ObjectMapper.Mapper.Map<ProductModel>(product);
            return mapped;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId)
        {
            var productList = await _productRepository.GetProductByCategoryAsync(categoryId);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);
            return mapped;
        }

        public async Task<ProductModel> Create(ProductModel productModel)
        {
            await ValidateProductIfExist(productModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Product>(productModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _productRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ProductModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(ProductModel productModel)
        {
            ValidateProductIfNotExist(productModel);
            
            var editProduct = await _productRepository.GetByIdAsync(productModel.Id);
            if (editProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<ProductModel, Product>(productModel, editProduct);

            await _productRepository.UpdateAsync(editProduct);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(ProductModel productModel)
        {
            ValidateProductIfNotExist(productModel);
            var deletedProduct = await _productRepository.GetByIdAsync(productModel.Id);
            if (deletedProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _productRepository.DeleteAsync(deletedProduct);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        private async Task ValidateProductIfExist(ProductModel productModel)
        {
            var existingEntity = await _productRepository.GetByIdAsync(productModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{productModel.ToString()} with this id already exists");
        }

        private void ValidateProductIfNotExist(ProductModel productModel)
        {
            var existingEntity = _productRepository.GetByIdAsync(productModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{productModel.ToString()} with this id is not exists");
        }
    }
}
