using damnoshApi.Data;
using damnoshApi.Dtos.Stock;
using damnoshApi.Interfaces;
using damnoshApi.Models;
using Microsoft.EntityFrameworkCore;

namespace damnoshApi.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var result = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return null;

            }
            _context.Stocks.Remove(result);
            await _context.SaveChangesAsync();
            return result;

        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> StockExist(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
            
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var result = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            result.Symbol = stockDto.Symbol;
            result.CompanyName = stockDto.CompanyName;
            result.Purchase = stockDto.Purchase;
            result.LastDiv = stockDto.LastDiv;
            result.Indestry = stockDto.Indestry;
            result.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();
            return result;

        }
    }
}