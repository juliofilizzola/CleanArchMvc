using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Add(CategoryDTO categoryDTO)
        {
            var body = _mapper.Map<Category>(categoryDTO);
            if (body == null) throw new BadImageFormatException();
            await _categoryRepository.Create(body);
            return categoryDTO;
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var result = await _categoryRepository.GetById(id);

            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var result = await _categoryRepository.GetCategories();

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task<bool> Remove(int? id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null) throw new KeyNotFoundException();

            var removeResult = await _categoryRepository.Remove(category);

            return removeResult != null;
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
            var bodyCategory = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(bodyCategory);
            return categoryDTO;
        }
    }
}
