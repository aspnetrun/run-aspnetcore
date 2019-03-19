using AspnetRun.Application.Dtos;
using AspnetRun.Core.Entities;
using AspnetRun.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    public interface IAspnetRunPageService<TEntity, TEntityDto, TEntityViewModel> 
        where TEntity : BaseEntity where TEntityDto : BaseDto where TEntityViewModel : BaseViewModel
    {
        Task<TEntityViewModel> GetById(int entityId);
        Task<IEnumerable<TEntityViewModel>> GetAll();
        Task<TEntityViewModel> Add(TEntityViewModel entityViewModel);
        Task Update(TEntityViewModel entityViewModel);
        Task Delete(TEntityViewModel entityViewModel);
    }
}
