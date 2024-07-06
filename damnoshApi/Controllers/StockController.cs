using damnoshApi.Data;
using damnoshApi.Dtos.Stock;
using damnoshApi.Mappers;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList()
            .Select(s => s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var result = stockDto.ToStockFromCreateDto();
            _context.Stocks.Add(result);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var result = _context.Stocks.FirstOrDefault(x => x.Id == id);
            if (result == null)
                return NotFound();

            result.Symbol = updateDto.Symbol;
            result.CompanyName = updateDto.CompanyName;
            result.Purchase = updateDto.Purchase;
            result.LastDiv = updateDto.LastDiv;
            result.Indestry = updateDto.Indestry;
            result.MarketCap = updateDto.MarketCap;

            _context.SaveChanges();
            return Ok(result.ToStockDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _context.Stocks.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return NotFound();

            }
            _context.Stocks.Remove(result);
            _context.SaveChanges();
            return NoContent();
        }
    }
}