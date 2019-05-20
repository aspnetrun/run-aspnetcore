using AspnetRun.Application.Models;
using AspnetRun.Web.ViewModels;
using AutoMapper;

namespace AspnetRun.Web.Mapper
{
    public class AspnetRunProfile : Profile
    {
        public AspnetRunProfile()
        {
            CreateMap<ProductModel, ProductViewModel>();
            CreateMap<CategoryModel, CategoryViewModel>();
        }
    }
}
