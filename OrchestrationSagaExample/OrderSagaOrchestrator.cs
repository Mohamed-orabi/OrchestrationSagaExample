using MediatR;

namespace OrchestrationSagaExample
{
    public class OrderSagaOrchestrator
    {
        private readonly IMediator _mediator;

        public OrderSagaOrchestrator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ExecuteOrderSaga(CreateOrderCommand createOrderCommand)
        {
            try
            {
                // Step 1: Create Order
                await _mediator.Send(createOrderCommand);

                // Step 2: Process Payment
                var processPaymentCommand = new ProcessPaymentCommand(
                    createOrderCommand.OrderId,
                    createOrderCommand.CustomerId,
                    createOrderCommand.TotalAmount
                );
                await _mediator.Send(processPaymentCommand);

                // Step 3: Reserve Inventory
                var reserveInventoryCommand = new ReserveInventoryCommand(createOrderCommand.OrderId);
                await _mediator.Send(reserveInventoryCommand);

                // If all steps succeed, complete the order
                await _mediator.Publish(new OrderCompleted(createOrderCommand.OrderId));
            }
            catch (Exception)
            {
                // If any step fails, trigger compensating transactions
                await _mediator.Send(new CancelOrderCommand(createOrderCommand.OrderId));
                await _mediator.Send(new RefundPaymentCommand(
                    createOrderCommand.OrderId,
                    createOrderCommand.CustomerId,
                    createOrderCommand.TotalAmount
                ));
                await _mediator.Send(new ReleaseInventoryCommand(createOrderCommand.OrderId));

                // Mark the order as failed
                await _mediator.Publish(new OrderFailed(createOrderCommand.OrderId));
            }
        }
    }
}
