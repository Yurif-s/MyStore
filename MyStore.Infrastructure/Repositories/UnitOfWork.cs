using MyStore.Domain.Interfaces;
using MyStore.Infrastructure.Data;

namespace MyStore.Infrastructure.Repositories;

internal class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken ct = default)
        => await context.SaveChangesAsync(ct);
}
