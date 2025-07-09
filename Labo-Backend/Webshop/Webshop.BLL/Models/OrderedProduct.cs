using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Models
{
    public class OrderedProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
