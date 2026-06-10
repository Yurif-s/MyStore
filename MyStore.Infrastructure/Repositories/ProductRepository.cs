using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure.Data;

namespace MyStore.Infrastructure.Repositories;

internal class ProductRepository(AppDbContext dbContext) : Repository<Product>(dbContext), IProductRepository
{
    public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId, CancellationToken ct = default)
        => await _dbContext.Products
            .AsNoTracking()
            .Where(p => p.CategoryId == categoryId && p.IsActive)
            .ToListAsync(ct);

    public async Task<IEnumerable<Product>> SearchAsync(string term, CancellationToken ct = default)
        => await _dbContext.Products
            .AsNoTracking()
            .Where(p => p.IsActive && (
                p.Name.Contains(term) ||
                p.Description.Contains(term)))
            .ToListAsync(ct);

    public async Task<bool> ExistsAsync(int id, CancellationToken ct = default)
        => await _dbContext.Products.AnyAsync(p => p.Id == id, ct);
}
