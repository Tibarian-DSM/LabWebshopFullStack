using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.DTO.OrderDTO
{
    public class CreateOrderDTO
    {
        [Required]
        
        public DateTime Date { get; set; }
        [Required]
        public int User_Id { get; set; }
    }
}
