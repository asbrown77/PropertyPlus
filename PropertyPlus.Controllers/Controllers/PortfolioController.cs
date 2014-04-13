using System.Collections.Generic;
using PropertyPlus.Interface;
using PropertyPlus.Repository.Interface;

namespace PropertyPlus.Controllers.Controllers
{
    public class PortfolioController
    {
        private readonly IPortfolioRepository portfolioRepository;

        public PortfolioController(IPortfolioRepository portfolioRepository)
        {
            this.portfolioRepository = portfolioRepository;
        }

        public IEnumerable<IProperty> GetProperties(int portfolioId)
        {      
            return portfolioRepository.GetProperties(portfolioId);
        }
    }
}