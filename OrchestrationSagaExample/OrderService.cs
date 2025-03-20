namespace OrchestrationSagaExample
{
    public class OrderService
    {
        private readonly List<Order> _orders = new();

        public Task Handle(CreateOrderCommand command)
        {
            var order = new Order
            {
                Id = command.OrderId,
                CustomerId = command.CustomerId,
                TotalAmount = command.TotalAmount
            };
            _orders.Add(order);

            // Publish OrderCreated event
            return Task.CompletedTask;
        }

        public Task Handle(CancelOrderCommand command)
        {
            var order = _orders.FirstOrDefault(o => o.Id == command.OrderId);
            if (order != null)
            {
                order.Status = "Cancelled";
            }

            return Task.CompletedTask;
        }
    }
}
