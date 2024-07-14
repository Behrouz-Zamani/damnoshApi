using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using damnoshApi.Dtos.Stock;
using damnoshApi.Models;

namespace damnoshApi.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock?> GetBySymbolAsync(string symbol);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id,UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExist(int id);

    }
}