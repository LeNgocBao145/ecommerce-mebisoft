using MediatR;

namespace ProductService.Application.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : IRequest<int>;
}
