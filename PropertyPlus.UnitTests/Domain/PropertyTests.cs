using System;
using Common.Testing;
using NUnit.Framework;
using PropertyPlus.Domain;
using PropertyPlus.Interface;
using Rhino.Mocks;


namespace PropertyPlusUnitTests.Domain
{
    public abstract class with_property : ContextTest
    {
        protected Property property;
        protected readonly IAddress stubAddress = MockRepository.GenerateStub<IAddress>();

        protected Property CreateProperty(IAddress address, decimal purchaseAmount, DateTime purchaseDate)
        {
            return new Property(address, purchaseAmount, purchaseDate);
        }
    }

    public class when_constructing_with_no_address_details : with_property
    {
        private Exception exception;

        protected override void Act()
        {
            exception = Trying(() => CreateProperty(null, 0, DateTime.MinValue));
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

    public class when_constructing_with_address_and_purchase_amount : with_property
    {
        private IAddress validAddress;
        private readonly decimal purchaseAmount = new decimal(1001.12);
        private readonly DateTime purchaseDate = DateTime.Parse("01 Jan 2014");

        protected override void Arrange()
        {
            validAddress = Address.Create(7, "North Meadow View", "TownX", "XXX XXX");
        }

        protected override void Act()
        {
            property = CreateProperty(validAddress, purchaseAmount, purchaseDate);
        }

        [Test]
        public void should_have_associated_address()
        {
            property.Address.ShouldEqual(validAddress);
        }

        [Test]
        public void should_have_purchase_details()
        {
            property.PurchaseAmount.ShouldEqual(purchaseAmount);  
        }        
        
        [Test]
        public void should_have_purchase_date()
        {
            property.PurchaseDate.ShouldEqual(purchaseDate);  
        }

        [Test]
        public void should_have_no_associated_mortgages()
        {
            property.AssociatedMortgages.ShouldBeEmpty();
        }
    }


    public class when_add_associated_mortgage : with_property
    {
        private IMortgage mortgage;

        protected override void Arrange()
        {
            property = CreateProperty(stubAddress, 0, DateTime.MinValue);
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
