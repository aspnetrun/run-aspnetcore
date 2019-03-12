using AspnetRun.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    public interface IProductRazorService
    {
        IEnumerable<ProductViewModel> GetProducts();
    }
}
