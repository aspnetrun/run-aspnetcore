using AspnetRun.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IEnumerable<ProductOutput>> GetProductList();
        Task<IEnumerable<ProductOutput>> GetProductByName(string productName);
        Task<IEnumerable<ProductOutput>> GetProductByCategory(int categoryId);
    }
}
