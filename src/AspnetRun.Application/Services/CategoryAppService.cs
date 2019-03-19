using AspnetRun.Application.Dtos;
using AspnetRun.Application.Infrastructure.Mapper;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class CategoryAppService : AspnetRunAppService<Category, CategoryDto>, ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(IAsyncRepository<Category> repository, IAppLogger<Category> logger, ICategoryRepository categoryRepository)
            : base(repository, logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<CategoryDto> GetCategoryWithProductsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryWithProductsAsync(categoryId);
            var mapped = ObjectMapper.Mapper.Map<CategoryDto>(category);
            return mapped;
        }

        public override Task<Category> Add(CategoryDto entityDto)
        {
            return base.Add(entityDto);
        }
    }
}
