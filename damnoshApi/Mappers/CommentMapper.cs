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
        public static Comment ToCommentDtoFromCreateDto(this CreateCommentRepository commentModels, int stockId)
        {
            return new Comment
            {
                
                Title = commentModels.Title,
                Content = commentModels.Content,
                StockId = stockId
            };
        }

        public static CommentDto ToCommentDtoFromUpdateDto(this UpdateCommandRepository updateDto)
        {
            return new CommentDto
            {
                // Id = updateDto.Id,
                Title = updateDto.Title,
                Content = updateDto.Content,
                // CreatedOn = updateDto.CreatedOn,

            };
        }
    }
}