using Domain.Shared.ValueObjects;


namespace Domain.Supporting.CustomerManagement
{
    public class Customer
    {
        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        private List<Feedback> _feedbackList = new List<Feedback>();
        public IReadOnlyCollection<Feedback> FeedbackList => _feedbackList.AsReadOnly();

        public Customer(Guid customerId, string name, string email, string phoneNumber, Address address)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void UpdateProfile(string name, string email, string phoneNumber, Address address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void SubmitFeedback(Guid orderId, int rating, string comments)
        {
            var feedback = new Feedback(orderId, rating, comments);
            _feedbackList.Add(feedback);
        }
    }
}
