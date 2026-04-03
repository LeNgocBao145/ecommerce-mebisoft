using OrderService.Domain.Entities;
using OrderService.Domain.Interfaces;
using System.Linq.Expressions;

namespace PromotionService.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Order> CreateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetByAsync(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
