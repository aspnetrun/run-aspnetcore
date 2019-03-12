using AspnetRun.Application.Interfaces;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class ProductRazorService : IProductRazorService
    {
        private readonly IProductAppService _productAppService;
        private readonly ILogger<ProductRazorService> _logger;

        public ProductRazorService(IProductAppService productAppService, ILogger<ProductRazorService> logger)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<ProductListViewModel> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
