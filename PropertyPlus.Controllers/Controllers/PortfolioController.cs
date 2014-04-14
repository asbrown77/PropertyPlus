using System.Collections.Generic;
using System.Web.Http;
using PropertyPlus.Interface;
using PropertyPlus.Repository.Interface;

namespace PropertyPlus.Controllers.Controllers
{
    public class PortfolioController : ApiController
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