using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using damnoshApi.Data;
using damnoshApi.Interfaces;
using damnoshApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace damnoshApi.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;
        public PortfolioRepository(ApplicationDBContext context)
        {
            
            _context=context;
        }
        public async Task<List<Stock>> GetUserPortfolio(AddUser user)
        {
            
            return await _context.Portfolios.Where(u => u.AppuserId == user.Id).Select
            (stock => new Stock{
                Id=stock.StockId,
                Symbol=stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDiv = stock.Stock.LastDiv,
                Indestry =stock.Stock.Indestry,
                MarketCap = stock.Stock.MarketCap
            }).ToListAsync();
        }
    }
}