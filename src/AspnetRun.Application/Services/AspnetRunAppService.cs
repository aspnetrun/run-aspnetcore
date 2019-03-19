using AspnetRun.Application.Dtos;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.
    public class AspnetRunAppService<TEntity, TEntityDto> : IAspnetRunAppService<TEntity, TEntityDto> where TEntity : BaseEntity where TEntityDto : BaseDto
    {        
        protected readonly IAsyncRepository<TEntity> _repository;
        protected readonly IAppLogger<TEntity> _logger;

        public AspnetRunAppService(IAsyncRepository<TEntity> repository, IAppLogger<TEntity> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public virtual async Task<TEntityDto> GetById(int entityId)
        {
            var entity = await _repository.GetByIdAsync(entityId);
            var mappedEntity = ObjectMapper.Mapper.Map<TEntityDto>(entity);
            return mappedEntity;
        }

        public virtual async Task<IEnumerable<TEntityDto>> GetAll()
        {
            var entityList = await _repository.GetAllAsync();
            var mappedEntityList = ObjectMapper.Mapper.Map<IEnumerable<TEntityDto>>(entityList);
            return mappedEntityList;
        }

        public virtual async Task<TEntityDto> Add(TEntityDto entityDto)
        {
            var existingEntity = await _repository.GetByIdAsync(entityDto.Id); 
            if (existingEntity != null)
                throw new ApplicationException($"{entityDto.ToString()} with this id already exists");

            var mappedEntity = ObjectMapper.Mapper.Map<TEntity>(entityDto);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _repository.AddAsync(mappedEntity);            
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<TEntityDto>(newEntity);
            return newMappedEntity;
        }

        public virtual async Task Update(TEntityDto entityDto)
        {
            var existingEntity = await _repository.GetByIdAsync(entityDto.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{entityDto.ToString()} with this id not exists");

            var mappedEntity = ObjectMapper.Mapper.Map<TEntity>(entityDto);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            await _repository.UpdateAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public virtual async Task Delete(TEntityDto entityDto)
        {
            var existingEntity = await _repository.GetByIdAsync(entityDto.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{entityDto.ToString()} with this id not exists");

            var mappedEntity = ObjectMapper.Mapper.Map<TEntity>(entityDto);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            await _repository.DeleteAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }
    }
}
