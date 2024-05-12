using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands;

public class ProductRemoveCommand(int id) : IRequest<Product> {
    public int Id { get; set; } = id;
}