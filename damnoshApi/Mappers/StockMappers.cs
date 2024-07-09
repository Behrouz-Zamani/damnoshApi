using damnoshApi.Dtos.Stack;
using damnoshApi.Dtos.Stock;
using damnoshApi.Models;

namespace damnoshApi.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Indestry = stockModel.Indestry,
                MarketCap = stockModel.MarketCap,
                Comments=stockModel.Comments.Select(c => c.ToCommentDto()).ToList(),

            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
        {
                return new Stock
                {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Indestry = stockDto.Indestry,
                MarketCap = stockDto.MarketCap,
                };
        }

        public static Stock ToStockFromUpdateDto(this UpdateStockRequestDto updateDto)
        {
                            return new Stock
                {
                Symbol = updateDto.Symbol,
                CompanyName = updateDto.CompanyName,
                Purchase = updateDto.Purchase,
                LastDiv = updateDto.LastDiv,
                Indestry = updateDto.Indestry,
                MarketCap = updateDto.MarketCap,
                };
        }
    }
}