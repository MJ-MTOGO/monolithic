using Domain.Shared.Ports;

namespace Infrastructure.Adapters
{
    public class NotificationServiceRepository : INotificationService
    {   
        public void SendNotification(Guid customerId, string message)
        {
            // Simulate sending a notification
            Console.WriteLine($"Notification to Customer {customerId}: {message}");
        }
    }
}
