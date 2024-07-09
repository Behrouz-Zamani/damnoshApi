using System.ComponentModel.DataAnnotations;

namespace damnoshApi.Dtos.Comment
{
    public class UpdateCommandRepository
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title Most be 5 charecters")]
        [MaxLength(280, ErrorMessage = "Title can not be over 280 charecters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content Most be 5 charecters")]
        [MaxLength(280, ErrorMessage = "Content can not be over 280 charecters")]
        public string Content { get; set; } = string.Empty;
        // public DateTime CreatedOn { get; set; }=DateTime.Now;
        // public int? StockId { get; set; }
    }
}