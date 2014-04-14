using System;
using System.Linq;
using NUnit.Framework;
using PropertyPlus.Domain;

namespace PropertyPlusUnitTests.Domain
{
    [TestFixture]
    public class PortfolioTests
    {
        private static Portfolio make_Portfolio(string portfolioName = "DefaultPortfolio")
        {
            return new Portfolio(portfolioName);
        }

        private static Property make_Property(string street = "XXXStreet")
        {
            var dateTime = DateTime.MinValue;
            var address = Address.Create(1, street, "xxTown", "xxx xxx");
            return new Property(address, (decimal) 1234.56, dateTime );
        }

        [Test]
        public void Construct_PortfolioNameSupplied_ReturnPortfolioWithTheGivenName()
        {
            var portfolio = make_Portfolio("XXX");

            Assert.AreEqual("XXX", portfolio.Name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Portfolio Name cant be null or empty")]
        public void Construct_NoPortfolioNameSupplied_ThrowException()
        {
            make_Portfolio("");
        }

        [Test]
        public void GetProperties_NoPropertiesInPorfolio_ReturnEmptyPropertyList()
        {
            var portfolio = make_Portfolio();

            Assert.IsEmpty(portfolio.Properties);
        }

        [Test]
        public void GetProperties_SinglePropertyInPortfolio_ReturnListWithSingleProperty()
        {
            var portfolio = make_Portfolio();
            var property = make_Property();
            portfolio.AddProperty(property);

            Assert.IsTrue(portfolio.Properties.Contains(property));
        }

        [Test]
        public void AddProperty_NoCurrentProperties_PropertyListCountIsIncremented()
        {
            var portfolio = make_Portfolio();
            portfolio.AddProperty(make_Property());

            Assert.IsNotEmpty(portfolio.Properties);
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException), ExpectedMessage = "Not a valid property for deletion")]
        public void DeleteProperty_NoCurrentProperties_ThrowsException()
        {
            var portfolio = make_Portfolio();
            const string irrelvantPropertyNameToDelete = "xxx";
            portfolio.DeleteProperty(irrelvantPropertyNameToDelete);
        }

        [Test]
        public void DeleteProperty_SinglePropertyPresentToBeDeleted_ReturnEmptyPropertyList()
        {
            var portfolio = make_Portfolio();
            var propertyToDelete = make_Property();
            portfolio.AddProperty(propertyToDelete);
            portfolio.DeleteProperty(propertyToDelete.Name);

            Assert.IsEmpty(portfolio.Properties);
        }

        [Test]
        public void DeleteProperty_TwoPropertiesPresentWithSecondToBeDeleted_ReturnSinglePropertyInPropertyList()
        {
            var portfolio = make_Portfolio();
            var firstProperty = make_Property("keep");
            var secondProperty = make_Property("delete");

            portfolio.AddProperty(firstProperty);
            portfolio.AddProperty(secondProperty);
            portfolio.DeleteProperty(secondProperty.Name);

            Assert.IsTrue(portfolio.Properties.Contains(firstProperty));
            Assert.AreEqual(1, portfolio.Properties.Count());
        }
    }
}
