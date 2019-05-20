using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class ProductPageService : IProductPageService
    {
        private readonly IProductService _productAppService;
        private readonly ICategoryService _categoryAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductPageService> _logger;

        public ProductPageService(IProductService productAppService, ICategoryService categoryAppService, IMapper mapper, ILogger<ProductPageService> logger)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                var list = await _productAppService.GetProductList();
                var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
                return mapped;
            }

            var listByName = await _productAppService.GetProductByName(productName);
            var mappedByName = _mapper.Map<IEnumerable<ProductViewModel>>(listByName);
            return mappedByName;
        }

        public async Task<ProductViewModel> GetProductById(int productId)
        {
            var product = await _productAppService.GetProductById(productId);
            var mapped = _mapper.Map<ProductViewModel>(product);
            return mapped;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductByCategory(int categoryId)
        {
            var list = await _productAppService.GetProductByCategory(categoryId);
            var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var list = await _categoryAppService.GetCategoryList();
            var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);
            return mapped;
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel)
        {
            var mapped = _mapper.Map<ProductModel>(productViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _productAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");

            var mappedViewModel = _mapper.Map<ProductViewModel>(entityDto);
            return mappedViewModel;
        }

        public async Task UpdateProduct(ProductViewModel productViewModel)
        {
            var mapped = _mapper.Map<ProductModel>(productViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _productAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

        public async Task DeleteProduct(ProductViewModel productViewModel)
        {
            var mapped = _mapper.Map<ProductModel>(productViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _productAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }
    }
}
