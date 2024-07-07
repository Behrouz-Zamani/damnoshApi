using damnoshApi.Data;
using damnoshApi.Dtos.Stock;
using damnoshApi.Interfaces;
using damnoshApi.Mappers;
using damnoshApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace damnoshApi.Controllers
{
    [Route("damnoshApi/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDBContext context,IStockRepository stockRepo)
        {
            _context = context;
            _stockRepo=stockRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks =await _stockRepo.GetAllAsync();

           var stockDto= stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock =await _stockRepo.GetByIdAsync(id);

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
            await _stockRepo.CreateAsync(result);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var result = await _stockRepo.UpdateAsync(id,updateDto);
            if (result == null)
                return NotFound();

            return Ok(result.ToStockDto());

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result =await _stockRepo.DeleteAsync(id);

            if (result == null)
            {
                return NotFound();

            }

            return NoContent();
        }
    }
}