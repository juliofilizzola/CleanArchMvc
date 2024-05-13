using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService(IMediator mediator, IMapper mapper) : IProductService {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper   _mapper   = mapper;
        public async Task<IEnumerable<ProductDto>> GetProducts() {
            var products = new GetProductsQuery();
            if (products == null) {
                throw new ApplicationException($"Entity could not be loaded");
            }

            var result = await _mediator.Send(products);
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto> GetProductById(int? id) {
            var product = new GetProductByIdQuery(id.Value);
            if (product == null) {
                throw new ApplicationException($"Product not found");
            }

            var result = await _mediator.Send(product);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task<ProductDto> Add(ProductDto productDto) {
            var bodyProduct = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(bodyProduct);
            return productDto;
        }

        public async Task<ProductDto> Update(ProductDto productDto) {
            var bodyProduct = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(bodyProduct);
            return productDto;
        }

        public async Task<bool>Remove(int? id) {
            var productSearch = new ProductRemoveCommand(id.Value);
            if (productSearch == null) {
                throw new ApplicationException($"Entity could not be loaded");
            }

            var removeProduct = await _mediator.Send(productSearch);
            return removeProduct != null;
        }
    }
}