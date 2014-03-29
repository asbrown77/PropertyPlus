using System;
using Common.Testing;
using NUnit.Framework;
using PropertyPlus.Domain;
using PropertyPlus.Interface;

namespace PropertyPlusTests
{
    public class when_constructing_with_no_address_details : ContextTest
    {
        private Exception exception;

        protected override void Act()
        {
            exception = Trying(() => {new Property(null);});
        }

        [Test]
        public void should_have_argument_exception()
        {
            exception.ShouldBeAnInstanceOf<ArgumentException>();
        }

        [Test]
        public void should_have_exception_message()
        {
            exception.Message.ShouldContain("Require associated address details");
        }
    }

    public class when_constructing_with_valid_address : ContextTest
    {
        private Property property;
        private IAddress validAddress;

        protected override void Arrange()
        {
            validAddress = Address.Create(7, "North Meadow View", "TownX", "XXX XXX");
        }

        protected override void Act()
        {
            property = new Property(validAddress);
        }

        [Test]
        public void should_have_associated_address()
        {
            property.Address.ShouldEqual(validAddress);
        }

        [Test]
        public void should_have_no_associated_mortgages()
        {
            property.AssociatedMortgages.ShouldBeEmpty();
        }
    }

    public class when_add_associated_mortgage : ContextTest
    {
        private Property property;
        private IAddress address;
        private IMortgage mortgage;

        protected override void Arrange()
        {
            address = Address.Create(7, "North Meadow View", "TownX", "XXX XXX");
            property = new Property(address);
            mortgage = new Mortgage();
        }

        protected override void Act()
        {
            property.AddMortgage(mortgage);
        }

        [Test]
        public void should_have_associated_mortgages_contain_added_mortgage()
        {
            property.AssociatedMortgages.ShouldContain(mortgage);
        }
    }
}
