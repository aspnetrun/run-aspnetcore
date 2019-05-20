using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Specifications;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AspnetRunContext dbContext) : base(dbContext)
        {            
        }

        public async Task<Category> GetCategoryWithProductsAsync(int categoryId)
        {            
            var spec = new CategoryWithProductsSpecification(categoryId);
            var category = (await GetAsync(spec)).FirstOrDefault();
            return category;
        }
    }
}
