using Common.Testing;
using NUnit.Framework;
using PropertyPlus.Domain;
using PropertyPlus.Interface;

namespace PropertyPlus.UnitTests.Domain
{
    public class when_constructoring_with_minimum_required_details : ContextTest
    {
        const int ExpectedHouseNumber = 1;
        const string ExpectedStreet = "7 North Meadow View";
        const string ExpectedTown = "Duston";
        const string ExpectedPostCode = "NN5 4UD";

        private IAddress address;

        protected override void Act()
        {
            address = Address.Create(ExpectedHouseNumber, ExpectedStreet, ExpectedTown, ExpectedPostCode);
        }

        [Test]
        public void should_have_expected_number()
        {
            address.Number.ShouldEqual(ExpectedHouseNumber);
        }

        [Test]
        public void Should_Have_Expected_Street()
        {
            Assert.AreEqual(ExpectedStreet, address.Street);
        }       
        
        [Test]
        public void Should_Have_Expected_Town()
        {
            Assert.AreEqual(ExpectedTown, address.Town);
        }   
        
        [Test]
        public void Should_Have_Expected_PostCode()
        {
            Assert.AreEqual(ExpectedPostCode, address.PostCode);
        }
    }
}
