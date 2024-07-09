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
        private readonly ApplicationDBContext _context;
        private readonly ICommentRepository _commentRepo;
        public CommentController(ApplicationDBContext context,ICommentRepository commentRipo)
        {
            _context = context;
            _commentRepo = commentRipo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =await _commentRepo.GetAllAsync();
            var commentDto =result.Select( s => s.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result=await _commentRepo.GetByIdAsync(id);
            if(result == null )
            {
                return NotFound();
            }
                return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommandRepository updateDto)
        {
            var result = await _commentRepo.UpdateAsync(id,updateDto);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var result = await _commentRepo.DeleteAsync(id);

            if (result == null)
            {
                 return NotFound();

            }
           return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentRepository commentDto)
        {
            var result =  commentDto.ToCommentDtoFromCreateDto();
            await _commentRepo.CreateAsync(result);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToCommentDto());

        }
    }
}