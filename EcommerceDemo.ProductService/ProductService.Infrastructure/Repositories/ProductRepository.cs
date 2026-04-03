using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext _context) : IProductRepository
    {
        public IQueryable<Product> GetQueryable()
        {
            return _context.Products.AsNoTracking(); // Trả về câu truy vấn "chưa thực thi"
        }
        public async Task<Product> CreateAsync(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return 0;

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SoftDeleteAsync(Guid id)
        {
            return await _context.Products.Where(p => p.Id == id).ExecuteUpdateAsync(p => p.SetProperty(x => x.IsDeleted, true));
        }

        public async Task<Product?> FindByIdAsync(Guid id)
        {
            return await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Categories)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Categories)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product?> GetByAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products
                .Where(predicate)
                .Include(p => p.Categories)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Product?> UpdateAsync(Product entity)
        {
            var existingProduct = await _context.Products.Where(p => !p.IsDeleted).FirstOrDefaultAsync(p => p.Id == entity.Id);
            if (existingProduct == null)
                return null;

            _context.Entry(existingProduct).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Products.Where(p => !p.IsDeleted).CountAsync();
        }
    }
}
