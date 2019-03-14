using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.UseCases.GetProductsByCategory
{
    public class GetProductsByCategoryUseCase : IGetProductsByCategoryUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByCategoryUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<ProductListOutput> Execute(int categoryId)
        {
            var productList = await _productRepository.GetProductByCategoryAsync(categoryId);
            var output = new ProductListOutput(productList);
            return output;
        }
    }
}
