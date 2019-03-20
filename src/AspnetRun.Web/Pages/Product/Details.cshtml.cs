using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;

namespace AspnetRun.Web.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly IProductPageService _productPageService;

        public DetailsModel(IProductPageService productPageService)
        {
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
        }       

        public ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productPageService.GetProductById(id.Value);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
