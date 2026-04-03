using Ecommerce.SharedLibrary.Interfaces;
using OrderService.Domain.Entities;

namespace OrderService.Domain.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
    }
}
