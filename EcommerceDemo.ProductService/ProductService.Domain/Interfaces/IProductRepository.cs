using Ecommerce.SharedLibrary.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public IQueryable<Product> GetQueryable();
        Task<int> SoftDeleteAsync(Guid id);
        Task<int> CountAsync();
    }
}
