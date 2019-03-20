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
        private readonly IMapper _mapper;

        public IndexPageService(IProductAppService productAppService, IMapper mapper)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var list = await _productAppService.GetProductList();
            var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            return mapped;
        }
    }
}
