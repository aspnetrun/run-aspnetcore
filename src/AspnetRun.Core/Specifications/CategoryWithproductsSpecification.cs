using AspnetRun.Core.Entities;
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

    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(string productName) 
            : base(p => p.ProductName.ToLower().Contains(productName.ToLower()))
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification() : base(null)            
        {
            AddInclude(p => p.Category);
        }
    }
}
