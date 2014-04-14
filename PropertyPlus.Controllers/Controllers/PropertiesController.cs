using System.Collections.Generic;
using System.Web.Http;
using PropertyPlus.Interface;
using PropertyPlus.Repository.Interface;

namespace PropertyPlus.Controllers.Controllers
{
    public class PropertiesController : ApiController
    {
        public PropertiesController()
        {
        }

        public IEnumerable<IProperty> GetPropertiesByPortfolioId(int portfolioId)
        {
            return new List<IProperty>();
        }
    }
}