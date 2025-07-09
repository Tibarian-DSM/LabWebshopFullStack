using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Webshop.API.Models.DTO.UserDTO
{
    public class UserUpdateForm
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string? Password { get; set; }
    }
}
