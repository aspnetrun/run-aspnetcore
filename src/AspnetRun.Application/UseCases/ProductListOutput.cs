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
        public List<ProductOutput> ProductOutputs { get; private set; } = new List<ProductOutput>();

        public ProductListOutput(IEnumerable<Product> products)
        {
            var ProductOutputs = ObjectMapper.Mapper.Map<IEnumerable<ProductOutput>>(products);            
        }
    }
}
