namespace OrchestrationSagaExample
{
    public abstract record Event(Guid OrderId);

    public record OrderCreated(Guid OrderId) : Event(OrderId);

    public record PaymentProcessed(Guid OrderId) : Event(OrderId);

    public record PaymentFailed(Guid OrderId) : Event(OrderId);

    public record InventoryReserved(Guid OrderId) : Event(OrderId);

    public record InventoryReservationFailed(Guid OrderId) : Event(OrderId);

    public record OrderCompleted(Guid OrderId) : Event(OrderId);

    public record OrderFailed(Guid OrderId) : Event(OrderId);
}
