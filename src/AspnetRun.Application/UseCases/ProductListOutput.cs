using AspnetRun.Application.Mapper;
using AspnetRun.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.UseCases
{
    public class ProductListOutput
    {
        public IEnumerable<ProductOutput> ProductOutputs { get; private set; } = new List<ProductOutput>();

        public ProductListOutput(IEnumerable<Product> products)
        {
            ProductOutputs = ObjectMapper.Mapper.Map<IEnumerable<ProductOutput>>(products);            
        }
    }
}
