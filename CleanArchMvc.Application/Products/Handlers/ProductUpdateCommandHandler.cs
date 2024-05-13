using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product> {
    private readonly IProductRepository _productRepository;

    public ProductUpdateCommandHandler(IProductRepository productRepository) {
        _productRepository = productRepository;
    }
    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken) {
        var searchProduct = await _productRepository.GetByIdAsync(request.Id);
        if (searchProduct == null) {
            throw new ApplicationException($"Product not found");
        }

        searchProduct.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

        return await _productRepository.UpdateAsync(product: searchProduct);
    }
}