using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductRazorService _productRazorService;

        public IndexModel(IProductRazorService productRazorService)
        {
            _productRazorService = productRazorService ?? throw new ArgumentNullException(nameof(productRazorService));
        }

        public IEnumerable<ProductViewModel> ProductModel { get; set; } = new List<ProductViewModel>();


        public void OnGet()
        {
            ProductModel = _productRazorService.GetProducts();
        }
    }
}
