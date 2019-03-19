using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class IndexPageService : AspnetRunPageService<Product, ProductDto, ProductViewModel>, IIndexPageService
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;

        public IndexPageService(IAspnetRunAppService<Product, ProductDto> appService, IMapper mapper, ILogger<ProductViewModel> logger, 
            IProductAppService productAppService, ICategoryAppService categoryAppService)
            : base(appService, mapper, logger)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
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

        public override Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return base.GetAll();
        }

    }
}
