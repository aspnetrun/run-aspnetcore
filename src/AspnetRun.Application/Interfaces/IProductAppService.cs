using AspnetRun.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Interfaces
{
    public interface IProductAppService
    {
        IList<ProductDto> GetProductList();
    }    
}
