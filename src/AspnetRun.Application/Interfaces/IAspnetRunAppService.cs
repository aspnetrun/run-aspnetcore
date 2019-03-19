using AspnetRun.Application.Dtos;
using AspnetRun.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IAspnetRunAppService<TEntity, TEntityDto> where TEntity : BaseEntity where TEntityDto : BaseDto
    {
        Task<TEntityDto> GetById(int entityId);
        Task<IEnumerable<TEntityDto>> GetAll();
        Task<TEntityDto> Add(TEntityDto entityDto);
        Task Update(TEntityDto entityDto);
        Task Delete(TEntityDto entityDto);
    }
}
