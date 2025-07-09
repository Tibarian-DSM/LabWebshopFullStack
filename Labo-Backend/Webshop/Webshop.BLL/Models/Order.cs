using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int User_Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }

        public List<OrderedProduct>? Products { get; set; }
        public string? Status { get; set; }
    }
}
