using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Interfaces
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(int categoryId);

    }
}
