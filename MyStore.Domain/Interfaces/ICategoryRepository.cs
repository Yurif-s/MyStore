using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetBySlugAsync(string slug, CancellationToken ct = default);
    Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken ct = default);
}
