using Domain.Shared.Ports;
using Domain.Shared.ValueObjects;


namespace Infrastructure.Adapters
{
    public class PaymentProcessorRepository : IPaymentProcessor
    {   
        public bool ProcessPayment(Guid orderId, Money amount)
        {
            // Simulate payment processing logic
            Console.WriteLine($"Processing payment for Order {orderId} with amount {amount}.");

            // Mock payment success if amount is positive
            return amount.Amount > 0;
        }
    }
}
