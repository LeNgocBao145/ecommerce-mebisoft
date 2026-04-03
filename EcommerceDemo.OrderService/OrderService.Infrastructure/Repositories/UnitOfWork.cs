using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Domain.Interfaces;

namespace OrderService.Infrastructure.Repositories
{
    public class UnitOfWork(DbContext context, IServiceProvider serviceProvider) : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;

        public ICartRepository UserRepository => serviceProvider.GetRequiredService<ICartRepository>();
        public IOrderRepository OrderRepository => serviceProvider.GetRequiredService<IOrderRepository>();

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
