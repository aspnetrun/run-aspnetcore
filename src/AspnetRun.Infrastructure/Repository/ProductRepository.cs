using AspnetRun.Core.Entities;
using AspnetRun.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Infrastructure.Repository
{
    public class ProductRepository : EfRepository<Product>
    {
        public ProductRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }
    }
}
