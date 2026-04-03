using MediatR;
using ProductService.Application.DTOs;

namespace ProductService.Application.Queries.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductDTO>;
}
