using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetRun.Core.Entities;
using AspnetRun.Infrastructure.Persistence;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;

namespace AspnetRun.Web.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly IIndexPageService _indexPageService;

        public CreateModel(IIndexPageService indexPageService)
        {
            _indexPageService = indexPageService ?? throw new ArgumentNullException(nameof(indexPageService));
        }       

        public IActionResult OnGetAsync()
        {
            // ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return Page();
        }

        [BindProperty]
        public ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product = await _indexPageService.CreateProduct(Product);
            return RedirectToPage("./Index");
        }
    }
}