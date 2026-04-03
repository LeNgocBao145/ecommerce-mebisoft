using MediatR;
using ProductService.Application.Common;
using ProductService.Application.DTOs;

namespace ProductService.Application.Queries.GetProducts
{
    public record GetProductsQuery(
        string Filter,
        string? CategoryName,
        int PageNumber = 1,
        int PageSize = 10
    ) : IRequest<PagedResponse<ProductDTO>>;
}
