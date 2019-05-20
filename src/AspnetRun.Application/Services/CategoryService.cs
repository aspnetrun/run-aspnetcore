using AspnetRun.Application.Mapper;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Core.Repositories;
using AspnetRun.Application.Models;

namespace AspnetRun.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, IAppLogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            var category = await _categoryRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<CategoryModel>>(category);
            return mapped;
        }        
        
    }
}
