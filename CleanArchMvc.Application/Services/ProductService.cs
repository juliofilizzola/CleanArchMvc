using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService(IProductRepository productService, IMapper mapper) : IProductService {
        public async Task<IEnumerable<ProductDTO>> GetProducts() {
            var products = await productService.GetProductsAsync();
            return mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductById(int? id) {
            var product = await productService.GetByIdAsync(id);
            return mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Add(ProductDTO productDto) {
            var bodyProduct = mapper.Map<Product>(productDto);
            await productService.CreateAsync(bodyProduct);
            return productDto;
        }

        public async Task<ProductDTO> Update(ProductDTO productDto) {
            var bodyProduct = mapper.Map<Product>(productDto);
            await productService.UpdateAsync(bodyProduct);
            return productDto;
        }

        public async Task<bool>Remove(int? id) {
            var product = productService.GetByIdAsync(id);
            if (product == null) throw new Exception();
            var bodyRemove = mapper.Map<Product>(product);

            var removeProduct = await productService.RemoveAsync(bodyRemove);
            return removeProduct != null;
        }
    }
}