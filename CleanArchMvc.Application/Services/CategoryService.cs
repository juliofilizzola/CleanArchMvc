using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService {
        public async Task<CategoryDTO> Add(CategoryDTO categoryDto)
        {
            var body = mapper.Map<Category>(categoryDto);
            if (body == null) throw new BadImageFormatException();
            await categoryRepository.Create(body);
            return categoryDto;
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var result = await categoryRepository.GetById(id);

            return mapper.Map<CategoryDTO>(result);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var result = await categoryRepository.GetCategories();

            return mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task<bool> Remove(int? id)
        {
            var category = await categoryRepository.GetById(id);
            if (category == null) throw new KeyNotFoundException();

            var removeResult = await categoryRepository.Remove(category);

            return removeResult != null;
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDto)
        {
            var bodyCategory = mapper.Map<Category>(categoryDto);
            await categoryRepository.Update(bodyCategory);
            return categoryDto;
        }
    }
}