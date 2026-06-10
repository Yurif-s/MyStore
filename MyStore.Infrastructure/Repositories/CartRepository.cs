using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure.Data;

namespace MyStore.Infrastructure.Repositories;

internal class CartRepository(AppDbContext dbContext)
    : Repository<Cart>(dbContext), ICartRepository
{
    public async Task<Cart?> GetByUserIdAsync(string userId, CancellationToken ct = default)
        => await _dbContext.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.UserId == userId, ct);
}
