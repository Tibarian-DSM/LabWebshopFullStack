using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.BLL.Mappers
{
    public static class OrderMapper
    {
        public static DAL.Models.Order BllToDal (this BLL.Models.Order order )
        {
            return new DAL.Models.Order
            {
                Date = order.Date,
                User_Id = order.User_Id,
            };
        }

        public static BLL.Models.Order DalToBll(this DAL.Models.Order order)
        {
            List<BLL.Models.OrderedProduct> products = new List<BLL.Models.OrderedProduct>();

            foreach (DAL.Models.OrderedProduct item in order.Products)
            {
                products.Add(item.DalToBll());
            }
            return new BLL.Models.Order
            {
                Id = order.Id,
                Date = order.Date,
                User_Id = order.User_Id,
                FirstName = order.FirstName,
                LastName = order.LastName,
                Email = order.Email,
                Products = products,
                Status = order.Status

            };
        }
    }
}
