using AspnetRun.Application.Interfaces;
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
    public class IndexPageService : IIndexPageService
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly ILogger<IndexPageService> _logger;
        private readonly IMapper _mapper;

        public IndexPageService(IProductAppService productAppService, ICategoryAppService categoryAppService, ILogger<IndexPageService> logger, IMapper mapper)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
    }
}
