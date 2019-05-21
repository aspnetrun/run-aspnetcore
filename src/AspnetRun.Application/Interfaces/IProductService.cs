using AspnetRun.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<ProductModel> GetProductById(int productId);
        Task<IEnumerable<ProductModel>> GetProductByName(string productName);
        Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId);
        Task<ProductModel> Create(ProductModel productModel);
        Task Update(ProductModel productModel);
        Task Delete(ProductModel productModel);
    }
}
