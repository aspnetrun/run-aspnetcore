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
    public class ProductRazorService : IProductRazorService
    {
        private readonly IProductAppService _productAppService;
        private readonly ILogger<ProductRazorService> _logger;
        private readonly IMapper _mapper;

        public ProductRazorService(IProductAppService productAppService, ILogger<ProductRazorService> logger, IMapper mapper)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            var list = _productAppService.GetProductList();
            var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            return mapped;
        }
    }
}
