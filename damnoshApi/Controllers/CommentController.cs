using damnoshApi.Data;
using damnoshApi.Dtos.Comment;
using damnoshApi.Interfaces;
using damnoshApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace damnoshApi.Controllers
{
    [Route("damnoshApi/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        // private readonly ApplicationDBContext _context;
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRipo, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _commentRepo = commentRipo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commentRepo.GetAllAsync();
            var commentDto = result.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _commentRepo.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommandRepository updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _commentRepo.UpdateAsync(id, updateDto);
            if (result == null)
            {
                return NotFound("Comment not found");
            }

            return Ok(result.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _commentRepo.DeleteAsync(id);

            if (result == null)
            {
                return NotFound("Comment dose not exist");

            }
            return Ok(result);
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentRepository commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!await _stockRepo.StockExist(stockId))
            {
                return BadRequest("Stock dose not exist");
            }


            var result = commentDto.ToCommentDtoFromCreateDto(stockId);
            await _commentRepo.CreateAsync(result);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToCommentDto());

        }
    }
}