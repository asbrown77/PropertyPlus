using PropertyPlus.Interface;

namespace PropertyPlus.Domain
{
    public class Address : IAddress
    {
        private Address()
        {    
        }

        public static IAddress Create(int number, string street, string town, string postCode)
        {
            return new Address {Number = number, Street = street, Town = town, PostCode = postCode};
        }

        public string Street { get; private set; }
        public string Town { get; private set; }
        public string PostCode { get; private set; }
        public int Number { get; private set; }
    }
}