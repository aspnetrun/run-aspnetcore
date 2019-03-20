using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspnetRun.Core.Entities;
using AspnetRun.Infrastructure.Persistence;

namespace AspnetRun.Web.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly AspnetRun.Infrastructure.Persistence.AspnetRunContext _context;

        public DetailsModel(AspnetRun.Infrastructure.Persistence.AspnetRunContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
