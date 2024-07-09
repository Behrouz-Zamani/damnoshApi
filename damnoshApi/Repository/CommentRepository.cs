using damnoshApi.Data;
using damnoshApi.Dtos.Comment;
using damnoshApi.Interfaces;
using damnoshApi.Models;
using Microsoft.EntityFrameworkCore;

namespace damnoshApi.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var result = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(result == null)
            {
                return null;
            }
            _context.Comments.Remove(result);
            await _context.SaveChangesAsync();
            return result;
            
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommandRepository updateComment)
        {
            var result=await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(result== null)
            {
                return null;
            }

            result.Content=updateComment.Content;
            result.Title=updateComment.Title;
            result.CreatedOn=updateComment.CreatedOn;
            result.StockId=updateComment.StockId;
           // result.Stock=updateComment.Stock;

           await _context.SaveChangesAsync();
           return result;
            
        }

    }
}