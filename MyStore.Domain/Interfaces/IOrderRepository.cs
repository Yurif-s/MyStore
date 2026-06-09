using MyStore.Domain.Entities;

namespace MyStore.Domain.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetByUserIdAsync(string userId, CancellationToken ct = default);
    Task<Order?> GetWithDetailsAsync(int id, CancellationToken ct = default); 
}
