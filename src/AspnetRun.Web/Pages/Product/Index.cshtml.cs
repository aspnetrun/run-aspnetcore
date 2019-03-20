using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspnetRun.Web.ViewModels;
using AspnetRun.Web.Interfaces;

namespace AspnetRun.Web.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductPageService _productPageService;

        public IndexModel(IProductPageService productPageService)
        {
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
        }

        public IEnumerable<ProductViewModel> ProductList { get; set; } = new List<ProductViewModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _productPageService.GetProducts(SearchTerm);
            return Page();
        }
    }
}
