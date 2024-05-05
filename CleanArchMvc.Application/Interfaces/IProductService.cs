using CleanArchMvc.Application.DTO;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task <ProductDto> GetProductById(int? id);
        Task <ProductDto> Add(ProductDto productDto);
        Task<ProductDto> Update(ProductDto productDto);
        Task<bool> Remove(int? id);
    }
}