using MyStore.Domain.Entities;

namespace MyStore.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId, CancellationToken ct = default);
    Task<IEnumerable<Product>> SearchAsync(string term, CancellationToken ct = default);
    Task<bool> ExistsAsync(int id, CancellationToken ct = default);
}
