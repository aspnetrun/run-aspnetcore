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
    public class ProductPageService : IProductPageService
    {
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductPageService> _logger;

        public ProductPageService(IProductAppService productAppService, ICategoryAppService categoryAppService, IMapper mapper, ILogger<ProductPageService> logger)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetProductByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetProducts(string productName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
