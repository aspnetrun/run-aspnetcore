using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.UseCases.GetProduct;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductRazorService _productRazorService;
        private readonly GetProductService _getProductService;

        public IndexModel(IProductRazorService productRazorService, GetProductService getProductService, IEnumerable<ProductViewModel> productModel)
        {
            _productRazorService = productRazorService ?? throw new ArgumentNullException(nameof(productRazorService));
            _getProductService = getProductService ?? throw new ArgumentNullException(nameof(getProductService));
            ProductModel = productModel ?? throw new ArgumentNullException(nameof(productModel));
        }

        public IEnumerable<ProductViewModel> ProductModel { get; set; } = new List<ProductViewModel>();
        public IEnumerable<ProductModel> ProductModel2 { get; set; } = new List<ProductModel>();


        public async Task<IActionResult> OnGet()
        {
            ProductModel2 = await _getProductService.GetProducts();

            ProductModel = await _productRazorService.GetProducts();
            return Page();


        }
    }
}
