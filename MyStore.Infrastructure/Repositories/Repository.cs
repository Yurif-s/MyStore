using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Interfaces;
using MyStore.Infrastructure.Data;

namespace MyStore.Infrastructure.Repositories;

internal class Repository<T>(AppDbContext dbContext) : IRepository<T> where T : class
{
    protected readonly AppDbContext _dbContext = dbContext;

    public async Task AddAsync(T entity, CancellationToken ct = default) 
        => await _dbContext.Set<T>().AddAsync(entity, ct);

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        => await _dbContext.Set<T>().AsNoTracking().ToListAsync(ct);

    public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        => await _dbContext.Set<T>().FindAsync([id], ct);

    public void Remove(T entity)
        => _dbContext.Set<T>().Remove(entity);

    public void Update(T entity)
        => _dbContext.Set<T>().Update(entity);
}
