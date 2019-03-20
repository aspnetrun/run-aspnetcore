using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class IndexPageService : IIndexPageService
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<IndexPageService> _logger;

        public IndexPageService(IProductAppService productAppService, ICategoryAppService categoryAppService, IMapper mapper, ILogger<IndexPageService> logger)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var list = await _productAppService.GetProductList();
            var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            return mapped;
        }

        public async Task<CategoryViewModel> GetCategoryWithProducts(int categoryId)
        {
            var categoryDto = await _categoryAppService.GetCategoryWithProductsAsync(categoryId);
            var mapped = _mapper.Map<CategoryViewModel>(categoryDto);
            return mapped;
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel)
        {
            var mapped = _mapper.Map<ProductDto>(productViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _productAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");

            var mappedViewModel = _mapper.Map<ProductViewModel>(entityDto);
            return mappedViewModel;
        }

        public async Task UpdateProduct(ProductViewModel productViewModel)
        {
            var mapped = _mapper.Map<ProductDto>(productViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _productAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

        public async Task DeleteProduct(ProductViewModel productViewModel)
        {
            var mapped = _mapper.Map<ProductDto>(productViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _productAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

    }
}
