using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
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

        public ProductAppService(IRepository<Product> productRepository)
        {            
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));            
        }        

        public IEnumerable<ProductDto> GetProductList()
        {            
            var productList = _productRepository.ListAll();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }
    }
}
