using Ecommerce.SharedLibrary.Interfaces;
using OrderService.Domain.Entities;

namespace OrderService.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
