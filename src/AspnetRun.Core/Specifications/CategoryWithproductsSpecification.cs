using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Specifications
{
    public sealed class CategoryWithProductsSpecification : BaseSpecification<Category>
    {
        public CategoryWithProductsSpecification(int categoryId)
            : base(b => b.Id == categoryId)
        {
            AddInclude(b => b.Products);
        }
    }    
}
