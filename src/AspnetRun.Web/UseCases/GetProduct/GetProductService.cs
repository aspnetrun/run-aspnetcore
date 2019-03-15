using AspnetRun.Application.UseCases.GetProductsByCategory;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.UseCases.GetProduct
{
    public class GetProductService
    {
        private readonly IGetProductsByCategoryUseCase _getProductsByCategoryUseCase;
        private readonly IMapper _mapper;

        public GetProductService(IGetProductsByCategoryUseCase getProductsByCategoryUseCase, IMapper mapper)
        {
            _getProductsByCategoryUseCase = getProductsByCategoryUseCase ?? throw new ArgumentNullException(nameof(getProductsByCategoryUseCase));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var list = await _getProductsByCategoryUseCase.Execute(1);
            var mapped = _mapper.Map<IEnumerable<ProductModel>>(list.ProductOutputs);
            return mapped;
        }

    }
}
