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
        private readonly IIndexPageService _indexPageService;

        public IndexModel(IIndexPageService indexPageService)
        {
            _indexPageService = indexPageService ?? throw new ArgumentNullException(nameof(indexPageService));
        }

        public IEnumerable<ProductViewModel> ProductModel { get; set; } = new List<ProductViewModel>();
        public CategoryViewModel CategoryModel { get; set; } = new CategoryViewModel();

        public async Task<IActionResult> OnGet()
        {
            // ProductModel = await _indexPageService.GetAll();

            //CategoryModel = await _indexPageService.GetCategoryWithProducts(1);
            //ProductModel = await _indexPageService.GetProducts();
            return Page();
        }
    }
}
