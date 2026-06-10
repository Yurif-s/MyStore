using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure.Data;

namespace MyStore.Infrastructure.Repositories;

internal class CategoryRepository(AppDbContext dbContext)
    : Repository<Category>(dbContext), ICategoryRepository
{
    public async Task<Category?> GetBySlugAsync(string slug, CancellationToken ct = default)
        => await _dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Slug == slug, ct);
}
