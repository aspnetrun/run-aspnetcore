using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
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

        public IList<ProductDto> GetProductList()
        {
            var asd = _productRepository.ListAll();

            throw new NotImplementedException();
        }
    }
}
