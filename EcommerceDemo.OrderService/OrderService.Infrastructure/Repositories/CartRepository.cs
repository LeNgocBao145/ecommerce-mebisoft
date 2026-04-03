using OrderService.Domain.Entities;
using OrderService.Domain.Interfaces;
using System.Linq.Expressions;

namespace OrderService.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        public Task<Cart> CreateAsync(Cart entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Cart?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cart?> GetByAsync(Expression<Func<Cart, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Cart?> UpdateAsync(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
