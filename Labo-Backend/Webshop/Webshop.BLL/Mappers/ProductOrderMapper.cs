using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Mappers
{
   public static class ProductOrderMapper
    {
        public static DAL.Models.ProductOrder BllToDal(this BLL.Models.ProductOrder PO)
        {
            return new DAL.Models.ProductOrder
            {
                Product_id = PO.Product_id,
                Order_id = PO.Order_id,
                Quantity=PO.Quantity
            };
        }
    }
}
