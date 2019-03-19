using AspnetRun.Application.Dtos;
using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IAspnetRunAppService<TEntity, TEntityDto> where TEntity : BaseEntity where TEntityDto : BaseDto
    {
        Task<TEntity> Add(TEntityDto entityDto);
    }
}
