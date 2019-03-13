using AspnetRun.Core.Entities;
using AspnetRun.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class ProductRepository : AspnetRunRepository<Product>
    {
        public ProductRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            return await _dbContext.Products
                .Where(x => x.ProductName.Contains(productName))
                .ToListAsync();
        }

    }
}
