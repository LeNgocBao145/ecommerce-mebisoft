using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace ProductService.Infrastructure.Repositories
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public async Task<Category> CreateAsync(Category entity)
        {
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var product = await _context.Categories.FindAsync(id);
            if (product == null)
                return 0;

            _context.Categories.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<Category?> FindByIdAsync(Guid id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category?> GetByAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _context.Categories
                .Where(predicate)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Category?> UpdateAsync(Category entity)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(p => p.Id == entity.Id);
            if (existingCategory == null)
                return null;

            _context.Entry(existingCategory).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}
