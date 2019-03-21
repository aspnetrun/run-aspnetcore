using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }        
        public ICollection<ProductDto> Products { get; set; }
    }
}
