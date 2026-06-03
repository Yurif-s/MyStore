using MyStore.Domain.Enums;

namespace MyStore.Domain.Entities;

public class Payment
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public string TransactionId { get; private set; } = string.Empty;
    public PaymentMethod Method { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime ProcessedAt { get; private set; }

    protected Payment() { }

    public Payment(int orderId, string transactionId, PaymentMethod method, decimal amount)
    {
        OrderId = orderId;
        TransactionId = transactionId;
        Method = method;
        Amount = amount;
        ProcessedAt = DateTime.UtcNow;
    }
}
