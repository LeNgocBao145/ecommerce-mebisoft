using AutoMapper;
using MediatR;
using ProductService.Application.DTOs;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository productRepository,
        IMapper mapper) : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updatedProduct = await productRepository.UpdateAsync(mapper.Map<Product>(request));
            if (updatedProduct == null)
            {
                return null;
            }
            return mapper.Map<ProductDTO>(updatedProduct);
        }
    }
}
