using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService(IProductRepository productService, IMapper mapper) : IProductService {
        public async Task<IEnumerable<ProductDto>> GetProducts() {
            var products = await productService.GetProductsAsync();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int? id) {
            var product = await productService.GetByIdAsync(id);
            return mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Add(ProductDto productDto) {
            var bodyProduct = mapper.Map<Product>(productDto);
            await productService.CreateAsync(bodyProduct);
            return productDto;
        }

        public async Task<ProductDto> Update(ProductDto productDto) {
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