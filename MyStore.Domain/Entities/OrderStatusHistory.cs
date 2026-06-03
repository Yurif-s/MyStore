using MyStore.Domain.Enums;

namespace MyStore.Domain.Entities;

public class OrderStatusHistory
{
    public int Id { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime OccurredAt { get; private set; }

    protected OrderStatusHistory() { }

    public OrderStatusHistory(OrderStatus status)
    {
        Status = status;
        OccurredAt = DateTime.UtcNow;
    }
}
