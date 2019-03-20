using AspnetRun.Core.Entities;
using AutoMapper;

namespace AspnetRun.Application.Dtos
{
    
    public class ProductDto : BaseDto
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
