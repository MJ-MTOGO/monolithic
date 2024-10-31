
namespace Domain.Shared.ValueObjects
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string Country { get; }

        public Address(string street, string city, string postalCode, string country)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }

        public override bool Equals(object obj)
        {
            if (obj is Address other)
                return Street == other.Street && City == other.City && PostalCode == other.PostalCode && Country == other.Country;
            return false;
        }

        public override int GetHashCode() => (Street, City, PostalCode, Country).GetHashCode();
    }
}
