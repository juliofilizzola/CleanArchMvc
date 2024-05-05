using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService {
        public async Task<CategoryDto> Add(CategoryDto categoryDto)
        {
            var body = mapper.Map<Category>(categoryDto);
            if (body == null) throw new BadImageFormatException();
            await categoryRepository.Create(body);
            return categoryDto;
        }

        public async Task<CategoryDto> GetById(int? id)
        {
            var result = await categoryRepository.GetById(id);

            return mapper.Map<CategoryDto>(result);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var result = await categoryRepository.GetCategories();

            return mapper.Map<IEnumerable<CategoryDto>>(result);
        }

        public async Task<bool> Remove(int? id)
        {
            var category = await categoryRepository.GetById(id);
            if (category == null) throw new KeyNotFoundException();

            var removeResult = await categoryRepository.Remove(category);

            return removeResult != null;
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            var bodyCategory = mapper.Map<Category>(categoryDto);
            await categoryRepository.Update(bodyCategory);
            return categoryDto;
        }
    }
}