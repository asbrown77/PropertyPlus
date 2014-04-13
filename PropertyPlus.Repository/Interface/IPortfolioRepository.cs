using System.Collections.Generic;
using PropertyPlus.Interface;

namespace PropertyPlus.Repository.Interface
{
    public interface IPortfolioRepository
    {
        IEnumerable<IProperty> GetProperties(int portfolioId);
    }
}