using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using damnoshApi.Dtos.Comment;
using damnoshApi.Models;

namespace damnoshApi.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModels)
        {
            return new CommentDto
            {
                Id = commentModels.Id,
                Title = commentModels.Title,
                Content = commentModels.Content,
                CreatedOn = commentModels.CreatedOn,
                StockId = commentModels.StockId
            };
        }
    }
}