using AspnetRun.Application.Interfaces.Mapping;
using AspnetRun.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Dtos
{
    public class ProductDto : IHaveCustomMapping
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public int? CategoryId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductDto>()
                .ForMember(pDTO => pDTO.ReorderLevel, opt => opt.MapFrom(p => p.ReorderLevel != null ? p.ReorderLevel : 1));            
        }
    }
}
