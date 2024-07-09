using damnoshApi.Dtos.Comment;
using damnoshApi.Models;

namespace damnoshApi.Mappers
{
    public static class CommentMapper
    {

        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
            };
        }
        public static Comment ToCommentDtoFromCreateDto(this CreateCommentRepository commentModels)
        {
            return new Comment
            {
                
                Title = commentModels.Title,
                Content = commentModels.Content,
                CreatedOn = commentModels.CreatedOn,
                StockId = commentModels.StockId
            };
        }

        public static CommentDto ToCommentDtoFromUpdateDto(this Comment updateDto)
        {
            return new CommentDto
            {
                Id = updateDto.Id,
                Title = updateDto.Title,
                Content = updateDto.Content,
                CreatedOn = updateDto.CreatedOn,
                StockId = updateDto.StockId
            };
        }
    }
}