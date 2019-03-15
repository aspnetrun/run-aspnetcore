using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.UseCases.GetProductsByCategory
{
    // NOTE : this design imported from here : https://github.com/ivanpaulovich/clean-architecture-manga
    // use case design -- folder structure combined by domain event and include interface-service-dto all. Also transfer this disipline to UI layer.
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
