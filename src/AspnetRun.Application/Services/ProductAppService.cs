using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductAppService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<ProductDto> GetProductList()
        {
            var productList = _productRepository.ListAll();
            var mapped = _mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }
    }
}
