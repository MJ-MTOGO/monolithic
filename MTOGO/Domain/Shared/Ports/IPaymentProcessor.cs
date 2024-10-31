using Domain.Shared.ValueObjects;


namespace Domain.Shared.Ports
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(Guid orderId, Money amount);
    }
}
