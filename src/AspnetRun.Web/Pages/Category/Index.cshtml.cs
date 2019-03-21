using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryPageService _categoryPageService;

        public IndexModel(ICategoryPageService categoryPageService)
        {
            _categoryPageService = categoryPageService ?? throw new ArgumentNullException(nameof(categoryPageService));
        }

        public IEnumerable<CategoryViewModel> CategoryList { get; set; } = new List<CategoryViewModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            CategoryList = await _categoryPageService.GetCategories();
            return Page();
        }
    }
}