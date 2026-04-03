using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using AuthService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthService.Infrastructure.Repositories
{
    public class UserRepository(UserDbContext context) : IUserRepository
    {
        public async Task<User> CreateAsync(User entity)
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<User?> GetByAsync(Expression<Func<User, bool>> predicate)
        {
            return await context.Users.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
