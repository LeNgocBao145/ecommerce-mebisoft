using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Application.Common;
using ProductService.Application.DTOs;
using ProductService.Domain.Exceptions;
using ProductService.Domain.Interfaces;
using System.Linq.Dynamic.Core;

namespace ProductService.Application.Queries.GetProducts
{
    public class GetProductsQueryHandler(IProductRepository productRepository,
        IMapper mapper) : IRequestHandler<GetProductsQuery, PagedResponse<ProductDTO>>
    {
        public async Task<PagedResponse<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            // 1. Lấy Queryable ban đầu (Chưa thực thi)
            var query = productRepository.GetQueryable().AsNoTracking();

            // 2. Áp dụng Filter trước khi đếm (Để TotalRecords chính xác theo kết quả tìm kiếm)
            if (!string.IsNullOrEmpty(request.Filter))
            {
                try
                {
                    query = query.Where(request.Filter);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Invalid filter expression: {request.Filter}", ex);
                }
            }

            // 3. Áp dụng filter theo tên category
            if (!string.IsNullOrEmpty(request.CategoryName))
            {
                query = query.Where(p => p.Categories.Any(c => c.Name.Contains(request.CategoryName)));
            }

            // 4. Đếm tổng số bản ghi (Chỉ gọi 1 lần duy nhất)
            var totalRecords = await query.CountAsync(cancellationToken);

            // 5. Tính toán Metadata
            var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

            if (totalRecords == 0)
            {
                return new PagedResponse<ProductDTO>
                {
                    Data = [],
                    Metadata = new PagedMetadata
                    {
                        PageNumber = request.PageNumber,
                        PageSize = request.PageSize,
                        TotalRecords = 0,
                        TotalPages = 0
                    }
                };
            }

            if (request.PageNumber > totalPages)
            {
                throw new InvalidParamsException("Invalid PageNumber param");
            }

            var paginationMetadata = new PagedMetadata
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages
            };

            // 6. THỰC HIỆN PHÂN TRANG (Skip và Take)
            // Lưu ý: Luôn phải có OrderBy trước khi Skip/Take để kết quả ổn định
            var data = await query
                .OrderBy("Id") // Hoặc một cột mặc định nào đó (Cần using System.Linq.Dynamic.Core)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectTo<ProductDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PagedResponse<ProductDTO>
            {
                Data = data,
                Metadata = paginationMetadata
            };
        }
    }
}
