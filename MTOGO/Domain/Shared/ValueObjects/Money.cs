

namespace Domain.Shared.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0) throw new ArgumentException("Amount cannot be negative", nameof(amount));
            if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("Currency cannot be empty", nameof(currency));

            Amount = amount;
            Currency = currency;
        }

        // Adds two Money objects if they have the same currency
        public Money Add(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Cannot add amounts with different currencies");

            return new Money(Amount + other.Amount, Currency);
        }

        // Subtracts two Money objects if they have the same currency
        public Money Subtract(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Cannot subtract amounts with different currencies");

            return new Money(Amount - other.Amount, Currency);
        }

        public override bool Equals(object obj)
        {
            if (obj is Money other)
                return Amount == other.Amount && Currency == other.Currency;

            return false;
        }

        public override int GetHashCode() => (Amount, Currency).GetHashCode();

        public override string ToString() => $"{Amount} {Currency}";
    }
}
