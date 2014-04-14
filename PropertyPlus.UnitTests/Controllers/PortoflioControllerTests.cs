using NUnit.Framework;
using PropertyPlus.Controllers.Controllers;
using PropertyPlus.Interface;
using PropertyPlus.Repository.Interface;
using Rhino.Mocks;

namespace PropertyPlus.UnitTests.Contollers
{
    [TestFixture]
    public class PortoflioControllerTests
    {
        [Test]
        public void GetProperties_ForPortfolio_ReturnListOfPortfolioProperties()
        {
            const int portfolioId = 1;
            var properties = new[]
            {
                MockRepository.GenerateStub<IProperty>()
            };

            var portfolioRepository = MockRepository.GenerateStub<IPortfolioRepository>();
            portfolioRepository.Stub(x => x.GetProperties(portfolioId)).Return(properties);

            var controller = new PortfolioController(portfolioRepository);

            var result = controller.GetProperties(portfolioId);

            Assert.AreEqual(properties, result);
        } 

    }
}

