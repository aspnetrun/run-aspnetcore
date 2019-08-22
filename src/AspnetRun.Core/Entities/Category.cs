using AspnetRun.Core.Entities.Base;
using System.Collections.Generic;
using System.Linq;

namespace AspnetRun.Core.Entities
{
    public class Category : Entity
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
    }
}
