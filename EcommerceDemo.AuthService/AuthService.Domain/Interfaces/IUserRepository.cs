using AuthService.Domain.Entities;
using System.Linq.Expressions;

namespace AuthService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User entity);
        Task<User?> GetByAsync(Expression<Func<User, bool>> predicate);
    }
}
