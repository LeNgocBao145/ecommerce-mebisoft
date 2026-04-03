using AutoMapper;
using MediatR;
using ProductService.Application.DTOs;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler(
        IProductRepository productRepository, IMapper mapper) : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            var createdProduct = await productRepository.CreateAsync(product);
            if (createdProduct == null)
            {
                return null;
            }
            return mapper.Map<ProductDTO>(createdProduct);
        }
    }
}
