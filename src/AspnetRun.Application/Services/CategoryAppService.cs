using AspnetRun.Application.Dtos;
using AspnetRun.Application.Infrastructure.Mapper;
using AspnetRun.Application.Interfaces;
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

        public CategoryAppService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<CategoryDto> GetCategoryWithProductsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryWithProductsAsync(categoryId);
            var mapped = ObjectMapper.Mapper.Map<CategoryDto>(category);
            return mapped;
        }
    }
}
