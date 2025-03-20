# OrchestrationSagaExample

- Orchestration-Based Saga
  
  - A central orchestrator (a dedicated service) coordinates the saga.
  - The orchestrator sends commands to each service to execute its local transaction.
  - The orchestrator handles failures and triggers compensating transactions if needed.
 
##  How It Works
  - A central orchestrator coordinates the saga.
  - The orchestrator sends commands to each service to execute its local transaction.
  - If a service fails, the orchestrator sends compensating commands to undo previous steps.

## Example: Order Processing Saga
Let’s say we have three services:

1. Order Service: Creates an order.
2. Payment Service: Processes the payment.
3. Inventory Service: Reserves items in the inventory.

Steps

1. The Orchestrator sends a CreateOrder command to the Order Service.
2. If successful, it sends a ProcessPayment command to the Payment Service.
3. If successful, it sends a ReserveInventory command to the Inventory Service.
4. If any step fails, the orchestrator sends compensating commands (e.g., CancelOrder, RefundPayment, ReleaseInventory).
