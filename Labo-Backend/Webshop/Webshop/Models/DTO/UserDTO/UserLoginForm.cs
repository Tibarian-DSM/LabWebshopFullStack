using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.DTO.UserDTO
{
    public class UserLoginForm
    {
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
