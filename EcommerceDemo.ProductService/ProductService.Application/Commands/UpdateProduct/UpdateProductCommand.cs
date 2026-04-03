using MediatR;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Commands.UpdateProduct
{
    public record UpdateProductCommand
    (
        Guid Id,
        string Name,
        string Description,
        int Stock,
        decimal Price,
        List<Guid> CategoryIds
    ) : IProductCommand, IRequest<ProductDTO>;
}
