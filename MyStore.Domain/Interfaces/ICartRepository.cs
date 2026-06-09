using MyStore.Domain.Entities;

namespace MyStore.Domain.Interfaces;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart?> GetByUserIdAsync(string userId, CancellationToken ct = default);
}
