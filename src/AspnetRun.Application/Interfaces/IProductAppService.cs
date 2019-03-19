using AspnetRun.Application.Dtos;
using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IProductAppService : IAspnetRunAppService<Product, ProductDto>
    {
        Task<IEnumerable<ProductDto>> GetProductList();
        Task<IEnumerable<ProductDto>> GetProductByName(string productName);
        Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId);
    }
}
