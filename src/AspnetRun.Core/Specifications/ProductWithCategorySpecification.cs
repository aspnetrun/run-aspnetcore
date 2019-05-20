using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
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
