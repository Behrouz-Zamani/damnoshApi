using damnoshApi.Dtos.Comment;
using damnoshApi.Models;

namespace damnoshApi.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id, UpdateCommandRepository updateComment);
        Task<Comment?> DeleteAsync(int id);
    }
}