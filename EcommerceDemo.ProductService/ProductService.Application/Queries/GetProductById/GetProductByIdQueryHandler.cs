using AutoMapper;
using MediatR;
using ProductService.Application.DTOs;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository,
        IMapper mapper) : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.FindByIdAsync(request.Id);
            if (product == null)
            {
                return null;
            }
            return mapper.Map<ProductDTO>(product);
        }
    }
}
