using CleanArchMvc.Application.DTO;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetById(int? id);
        Task<CategoryDto> Add(CategoryDto categoryDto);
        Task<CategoryDto> Update(CategoryDto categoryDto);
        Task<bool> Remove(int? id);
    }
}