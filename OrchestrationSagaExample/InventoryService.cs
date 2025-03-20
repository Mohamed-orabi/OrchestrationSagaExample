namespace OrchestrationSagaExample
{
    public class InventoryService
    {
        public Task Handle(ReserveInventoryCommand command)
        {
            // Simulate inventory reservation
            Console.WriteLine($"Reserving inventory for order {command.OrderId}...");
            return Task.CompletedTask;
        }

        public Task Handle(ReleaseInventoryCommand command)
        {
            // Simulate inventory release
            Console.WriteLine($"Releasing inventory for order {command.OrderId}...");
            return Task.CompletedTask;
        }
    }
}
