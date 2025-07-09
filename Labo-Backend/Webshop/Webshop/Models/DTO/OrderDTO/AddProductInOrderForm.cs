using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.DTO.OrderDTO
{
    public class AddProductInOrderForm
    {
        [Required]
        public int Product_Id { get; set; }
        [Required]
        public int Order_Id { get; set; }

        [DefaultValue(1)]
        public int Quantity { get; set; }
    }
}
