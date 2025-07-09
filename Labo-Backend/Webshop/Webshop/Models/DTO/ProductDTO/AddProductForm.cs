using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.DTO.ProductDTO
{
    public class AddProductForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Category { get; set; }

        public string Image { get; set; } = string.Empty;

    }
}
