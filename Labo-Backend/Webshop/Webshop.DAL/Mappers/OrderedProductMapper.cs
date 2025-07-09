using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.DAL.Mappers
{
    public static class OrderedProductMapper
    {
        public static OrderedProduct OPDbToDal(this IDataRecord record)
        {
            return new OrderedProduct
            {
                Name = (string)record["Name"],
                Price = Convert.ToDouble(record["Price"]),
                Quantity = (int)record["Quantity"]
            };
        }
    }
}
