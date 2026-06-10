using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure.Data;

namespace MyStore.Infrastructure.Repositories;

internal class OrderRepository(AppDbContext dbContext)
    : Repository<Order>(dbContext), IOrderRepository
{
    public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId, CancellationToken ct = default)
        => await _dbContext.Orders
            .AsNoTracking()
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync(ct);

    public async Task<Order?> GetWithDetailsAsync(int id, CancellationToken ct = default)
        => await _dbContext.Orders
            .Include(o => o.Items)
            .Include(o => o.History)
            .Include(o => o.Payment)
            .FirstOrDefaultAsync(o => o.Id == id, ct);
}
