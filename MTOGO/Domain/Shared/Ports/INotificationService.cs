namespace Domain.Shared.Ports
{
    public interface INotificationService
    {
        void SendNotification(Guid customerId, string message);
    }
}
