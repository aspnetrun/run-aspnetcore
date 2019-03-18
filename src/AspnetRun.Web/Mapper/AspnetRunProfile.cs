using AspnetRun.Application.Dtos;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Mapper
{
    public class AspnetRunProfile : Profile
    {
        public AspnetRunProfile()
        {
            CreateMap<ProductDto, ProductViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
        }
    }
}
