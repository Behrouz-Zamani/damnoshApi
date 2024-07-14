using damnoshApi.Models;

namespace damnoshApi.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AddUser user);
    }
}