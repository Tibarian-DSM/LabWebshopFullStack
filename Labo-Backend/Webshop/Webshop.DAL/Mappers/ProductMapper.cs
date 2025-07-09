using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.DAL.Mappers
{
    public static class ProductMapper
    {
        public static Product ProductDbToDal(this IDataRecord record)
        {
            return new Product()
            {
                    Id=(int)record["Id"],
                    Name=(string)record["Name"],
                    Price= Convert.ToDouble(record["Price"]),
                    Description=(string)record["Description"],
                    Category=(string)record["Category"],
                    Image= (string)record["Image"]
            };
        }
    }
}
