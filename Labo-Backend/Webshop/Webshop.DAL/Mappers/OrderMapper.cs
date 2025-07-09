using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.DAL.Mappers
{
    public static class OrderMapper
    {
        public static Order OrderDbToDal(this IDataRecord record)
        {
            return new Order()
            {
                Id = (int)record["Id"],
                Date=(DateTime)record["Date"],
                User_Id=(int)record["User_id"],
                FirstName = (string)record["FirstName"],
                LastName = (string)record["LastName"],
                Email = (string)record["Email"],
                Status = (string)record["OrderStatus"]
            };
        }
    }
}
