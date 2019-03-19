using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class AspnetRunPageService<TEntity, TEntityDto, TEntityViewModel> : IAspnetRunPageService where TEntity : BaseEntity where TEntityDto : BaseDto where TEntityViewModel : BaseViewModel
    {
        private readonly IAspnetRunAppService<TEntity, TEntityDto> _aspnetRunAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<TEntityViewModel> _logger;

        public AspnetRunPageService(IAspnetRunAppService<TEntity, TEntityDto> aspnetRunAppService, IMapper mapper, ILogger<TEntityViewModel> logger)
        {
            _aspnetRunAppService = aspnetRunAppService ?? throw new ArgumentNullException(nameof(aspnetRunAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public virtual async Task<TEntityViewModel> GetById(int entityId)
        {
            var entityDto = await _aspnetRunAppService.GetById(entityId);
            var mapped = _mapper.Map<TEntityViewModel>(entityDto);
            return mapped;
        }

        public virtual async Task<IEnumerable<TEntityViewModel>> GetAll()
        {
            var entityDtoList = await _aspnetRunAppService.GetAll();
            var mapped = _mapper.Map<IEnumerable<TEntityViewModel>>(entityDtoList);
            return mapped;
        }

        public virtual async Task<TEntityViewModel> Add(TEntityViewModel entityViewModel)
        {
            var mapped = _mapper.Map<TEntityDto>(entityViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _aspnetRunAppService.Add(mapped);
            _logger.LogInformation($"Entity successfully added - AspnetRunPageService");

            var mappedViewModel = _mapper.Map<TEntityViewModel>(entityDto);
            return mappedViewModel;
        }

        public virtual async Task Update(TEntityViewModel entityViewModel)
        {
            var mapped = _mapper.Map<TEntityDto>(entityViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _aspnetRunAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully updated - AspnetRunPageService");
        }

        public virtual async Task Delete(TEntityViewModel entityViewModel)
        {
            var mapped = _mapper.Map<TEntityDto>(entityViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _aspnetRunAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunPageService");
        }
    }
}
