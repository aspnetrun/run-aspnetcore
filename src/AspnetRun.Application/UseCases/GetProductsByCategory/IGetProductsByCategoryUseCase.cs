using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.UseCases.GetProductsByCategory
{
    public interface IGetProductsByCategoryUseCase
    {
        Task<ProductListOutput> Execute(int categoryId);
    }
}
