using CleanArchMvc.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? id);
        Task<CategoryDTO> Add(CategoryDTO categoryDTO);
        Task<CategoryDTO> Update(CategoryDTO categoryDTO);
        Task<Boolean> Remove(int? id);
    }
}
