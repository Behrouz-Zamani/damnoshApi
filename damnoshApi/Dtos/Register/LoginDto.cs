using System.ComponentModel.DataAnnotations;

namespace damnoshApi.Dtos.Register
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; } 
        [Required]
        public string Password { get; set; } 
    }
}