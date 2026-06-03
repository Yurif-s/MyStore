using MyStore.Domain.Enums;
using MyStore.Domain.Exceptions;

namespace MyStore.Domain.Entities;

public class Order
{
    public int Id { get; private set; }
    public string UserId { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal Total { get; private set; }

    private readonly List<OrderItem> _items = [];
    public IReadOnlyCollection<OrderItem> Items => _items;

    private readonly List<OrderStatusHistory> _history = [];
    public IReadOnlyCollection<OrderStatusHistory> History => _history;

    public Payment? Payment { get; private set; }

    protected Order() { }

    public static Order CreateFromCart(Cart cart)
    {
        if (!cart.Items.Any()) throw new DomainException("Cart is empty.");

        var order = new Order
        {
            UserId = cart.UserId,
            CreatedAt = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            Total = cart.Total
        };

        foreach (var item in cart.Items)
            order._items.Add(new OrderItem(item.ProductId, item.UnitPrice, item.Quantity));

        order._history.Add(new OrderStatusHistory(OrderStatus.Pending));

        return order;
    }

    public void AdvanceStatus(OrderStatus newStatus)
    {
        var validTransitions = new Dictionary<OrderStatus, OrderStatus[]>
        {
            [OrderStatus.Pending] = [OrderStatus.Paid, OrderStatus.Cancelled],
            [OrderStatus.Paid] = [OrderStatus.StockReserved, OrderStatus.Cancelled],
            [OrderStatus.StockReserved] = [OrderStatus.Shipped],
            [OrderStatus.Shipped] = [OrderStatus.Delivered],
        };

        if (!validTransitions.TryGetValue(Status, out var allowed) || !allowed.Contains(newStatus))
            throw new DomainException($"Invalid transition: {Status} → {newStatus}.");

        Status = newStatus;
        _history.Add(new OrderStatusHistory(newStatus));
    }

    public void RegisterPayment(string transactionId, PaymentMethod method)
    {
        if (Status != OrderStatus.Pending)
            throw new DomainException("Order is not awaiting payment.");

        Payment = new Payment(Id, transactionId, method, Total);
        AdvanceStatus(OrderStatus.Paid);
    }
}