using AspnetRun.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IEnumerable<ProductDto>> GetProductList();
        Task<ProductDto> GetProductById(int productId);
        Task<IEnumerable<ProductDto>> GetProductByName(string productName);
        Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId);
        Task<ProductDto> Create(ProductDto entityDto);
        Task Update(ProductDto entityDto);
        Task Delete(ProductDto entityDto);
    }
}
