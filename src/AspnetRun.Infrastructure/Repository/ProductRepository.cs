using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class ProductRepository : AspnetRunRepository<Product>, IProductRepository
    {
        public ProductRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            return await this.ListAllAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string productName)
        {
            return await _dbContext.Products
                .Where(x => x.ProductName.Contains(productName))
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products
                .Where(x => x.CategoryId==categoryId)
                .ToListAsync();
        }        
    }
}
