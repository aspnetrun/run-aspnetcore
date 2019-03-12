using AspnetRun.Application.Dtos;
using AspnetRun.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Mapper
{
    public class ObjectMapper
    {
        public static IMapper Mapper
        {
            get
            {
                return AutoMapper.Mapper.Instance;
            }
        }
        static ObjectMapper()
        {
            CreateMap();
        }

        private static void CreateMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
            });
        }
    }
}
