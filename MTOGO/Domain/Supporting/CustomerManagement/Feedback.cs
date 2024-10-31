
namespace Domain.Supporting.CustomerManagement
{
    public class Feedback
    {
        public Guid FeedbackId { get; private set; }
        public Guid OrderId { get; private set; }
        public int Rating { get; private set; } // Rating out of 5
        public string Comments { get; private set; }
        public DateTime SubmittedAt { get; private set; }

        public Feedback(Guid orderId, int rating, string comments)
        {
            FeedbackId = Guid.NewGuid();
            OrderId = orderId;
            Rating = rating;
            Comments = comments;
            SubmittedAt = DateTime.UtcNow;
        }
    }
}
