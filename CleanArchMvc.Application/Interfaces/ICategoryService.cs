using CleanArchMvc.Application.DTO;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? id);
        Task<CategoryDTO> Add(CategoryDTO categoryDto);
        Task<CategoryDTO> Update(CategoryDTO categoryDto);
        Task<Boolean> Remove(int? id);
    }
}