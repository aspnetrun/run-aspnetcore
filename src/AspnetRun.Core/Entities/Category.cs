using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string CategoryName { get; set; }
        public string Description { get; set; }        
        public ICollection<Product> Products { get; private set; }

        public static Category Create(int categoryId, string name, string description = null)
        {
            var category = new Category
            {
                Id = categoryId,
                CategoryName = name,
                Description = description
            };
            return category;
        }

        public void AddProduct(int productId, string productName)
        {
            if (!Products.Any(p => p.Id == productId))
            {
                Products.Add(Product.Create(productId, this.Id, productName));
            }
        }
    }
}
