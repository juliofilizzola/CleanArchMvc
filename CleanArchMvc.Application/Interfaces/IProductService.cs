using CleanArchMvc.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task <ProductDTO> GetProductById(int? id);
        Task <ProductDTO> Add(ProductDTO productDTO);
        Task<ProductDTO> Update(ProductDTO productDTO);
        Task<Boolean> Remove(int? id);
    }
}
