namespace OrchestrationSagaExample
{
    public class PaymentService
    {
        public Task Handle(ProcessPaymentCommand command)
        {
            // Simulate payment processing
            Console.WriteLine($"Processing payment for order {command.OrderId}...");
            return Task.CompletedTask;
        }

        public Task Handle(RefundPaymentCommand command)
        {
            // Simulate payment refund
            Console.WriteLine($"Refunding payment for order {command.OrderId}...");
            return Task.CompletedTask;
        }
    }
}
