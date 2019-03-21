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
    // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<ProductAppService> _logger;

        public ProductAppService(IProductRepository productRepository, IAppLogger<ProductAppService> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductDto>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var mapped = ObjectMapper.Mapper.Map<ProductDto>(product);
            return mapped;
        }

        public async Task<IEnumerable<ProductDto>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }

        public async Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId)
        {
            var productList = await _productRepository.GetProductByCategoryAsync(categoryId);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }

        public async Task<ProductDto> Create(ProductDto entityDto)
        {
            await ValidateProductIfExist(entityDto);

            var mappedEntity = ObjectMapper.Mapper.Map<Product>(entityDto);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _productRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ProductDto>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(ProductDto entityDto)
        {
            ValidateProductIfNotExist(entityDto);

            var mappedEntity = ObjectMapper.Mapper.Map<Product>(entityDto);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            await _productRepository.UpdateAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(ProductDto entityDto)
        {
            ValidateProductIfNotExist(entityDto);

            var mappedEntity = ObjectMapper.Mapper.Map<Product>(entityDto);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            await _productRepository.DeleteAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        private async Task ValidateProductIfExist(ProductDto entityDto)
        {
            var existingEntity = await _productRepository.GetByIdAsync(entityDto.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{entityDto.ToString()} with this id already exists");
        }

        private void ValidateProductIfNotExist(ProductDto entityDto)
        {
            var existingEntity = _productRepository.GetByIdAsync(entityDto.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{entityDto.ToString()} with this id is not exists");
        }
    }
}
