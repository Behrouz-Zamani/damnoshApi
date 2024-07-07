using damnoshApi.Data;
using damnoshApi.Dtos.Stock;
using damnoshApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace damnoshApi.Controllers
{
    [Route("damnoshApi/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks =await _context.Stocks.ToListAsync();

           var stockDto= stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock =await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var result = stockDto.ToStockFromCreateDto();
          await  _context.Stocks.AddAsync(result);
           await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var result =await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return NotFound();

            result.Symbol = updateDto.Symbol;
            result.CompanyName = updateDto.CompanyName;
            result.Purchase = updateDto.Purchase;
            result.LastDiv = updateDto.LastDiv;
            result.Indestry = updateDto.Indestry;
            result.MarketCap = updateDto.MarketCap;

            await _context.SaveChangesAsync();
            return Ok(result.ToStockDto());

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result =await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return NotFound();

            }
            _context.Stocks.Remove(result);
           await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}