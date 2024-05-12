using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product> {
    private readonly IProductRepository _productRepository;

    public ProductRemoveCommandHandler(IProductRepository productRepository) {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken) {
        var searchProduct = await _productRepository.GetByIdAsync(request.Id);
        if (searchProduct == null) {
            throw new ApplicationException($"Product not found");
        }

        return await _productRepository.RemoveAsync(searchProduct);
    }
}