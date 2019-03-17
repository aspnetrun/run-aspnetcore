using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductPageService _productRazorService;

        public IndexModel(IProductPageService productRazorService)
        {
            _productRazorService = productRazorService ?? throw new ArgumentNullException(nameof(productRazorService));
        }

        public IEnumerable<ProductViewModel> ProductModel { get; set; } = new List<ProductViewModel>();

        public async Task<IActionResult> OnGet()
        {
            ProductModel = await _productRazorService.GetProducts();
            return Page();
        }
    }
}
