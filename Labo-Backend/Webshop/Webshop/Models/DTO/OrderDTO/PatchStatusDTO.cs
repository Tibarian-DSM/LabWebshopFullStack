using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Webshop.API.Models.DTO.OrderDTO
{
    public class PatchStatusDTO
    {

        [Required]
        public string Status{ get; set; }
    }
}
