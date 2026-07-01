using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure.Data;

namespace MyStore.Infrastructure.Repositories;

internal class CategoryRepository(AppDbContext dbContext)
    : Repository<Category>(dbContext), ICategoryRepository
{
    public async Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default)
        => await _dbContext.Categories
            .AsNoTracking()
            .AnyAsync(c => c.Name == name);

    public async Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken ct = default)
        => await _dbContext.Categories
            .AsNoTracking()
            .Where(c => ids.Contains(c.Id))
            .ToListAsync(ct);

    public async Task<Category?> GetBySlugAsync(string slug, CancellationToken ct = default)
        => await _dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Slug == slug, ct);
}
