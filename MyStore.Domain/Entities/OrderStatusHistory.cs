using MyStore.Domain.Enums;

namespace MyStore.Domain.Entities;

public class OrderStatusHistory
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime OccurredAt { get; private set; }

    protected OrderStatusHistory() { }

    public OrderStatusHistory(int orderId, OrderStatus status)
    {
        OrderId = orderId;
        Status = status;
        OccurredAt = DateTime.UtcNow;
    }
}
