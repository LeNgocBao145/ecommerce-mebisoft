using MediatR;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, int>
    {
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.SoftDeleteAsync(request.Id);
        }
    }
}
