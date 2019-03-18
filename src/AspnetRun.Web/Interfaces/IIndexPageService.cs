using AspnetRun.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    // NOTE : This is the whole page service, it could be include all categories and products
    // this is the razor page based service
    public interface IIndexPageService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<CategoryViewModel> GetCategoryWithProducts(int categoryId);
    }
}
