using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Specifications;
using AspnetRun.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class CategoryRepository : AspnetRunRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Category>> GetCategoryWithProductsAsync(int categoryId)
        {
            var spec = new CategoryWithProductsSpecification(categoryId);



            throw new NotImplementedException();
        }
    }
}
