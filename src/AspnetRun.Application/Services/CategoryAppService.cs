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
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<CategoryAppService> _logger;

        public CategoryAppService(ICategoryRepository categoryRepository, IAppLogger<CategoryAppService> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryList()
        {
            var category = await _categoryRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<CategoryDto>>(category);
            return mapped;
        }        
        
    }
}
