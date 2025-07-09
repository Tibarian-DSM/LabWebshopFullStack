using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Models;

namespace Webshop.BLL.Mappers
{
   public static class OrderedProductMapper
    {
        public static OrderedProduct DalToBll(this DAL.Models.OrderedProduct product)
        {
            return new OrderedProduct
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }
    }
}
