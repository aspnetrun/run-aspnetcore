using AspnetRun.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IEnumerable<ProductDto>> GetProductList();
        Task<IEnumerable<ProductDto>> GetProductByName(string productName);
        Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId);
    }
}
