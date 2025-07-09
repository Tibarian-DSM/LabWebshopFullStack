using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.DAL.Mappers
{
    public static  class ProductOrderMapper
    {
        public static ProductOrder DbToDal(this IDataRecord record)
        {
            return new ProductOrder()
            {
                Id = (int)record["Id"],
                Order_id = (int)record["Order_id"],
                Product_id = (int)record["Product_id"],
                Quantity = (int)record["Quantity"]
            };
                    
        }
    }
}
