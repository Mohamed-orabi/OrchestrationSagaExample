namespace OrchestrationSagaExample
{
    public abstract record Command(Guid OrderId);

    public record CreateOrderCommand(Guid OrderId, Guid CustomerId, decimal TotalAmount) : Command(OrderId);

    public record ProcessPaymentCommand(Guid OrderId, Guid CustomerId, decimal Amount) : Command(OrderId);

    public record ReserveInventoryCommand(Guid OrderId) : Command(OrderId);

    public record CancelOrderCommand(Guid OrderId) : Command(OrderId);

    public record RefundPaymentCommand(Guid OrderId, Guid CustomerId, decimal Amount) : Command(OrderId);

    public record ReleaseInventoryCommand(Guid OrderId) : Command(OrderId);
}
