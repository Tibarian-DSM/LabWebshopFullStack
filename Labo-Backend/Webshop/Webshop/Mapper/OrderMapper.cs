using Webshop.API.Models.DTO.OrderDTO;
using Webshop.BLL.Models;

namespace Webshop.API.Mapper
{
    public static class OrderMapper
    {
        public static BLL.Models.Order ApiToBll(this CreateOrderDTO order)
        {
            return new BLL.Models.Order
            {
                Date = order.Date,
                User_Id = order.User_Id,
            };
        }

        public static BLL.Models.ProductOrder ApiToBll(this AddProductInOrderForm prod)
        {
            return new BLL.Models.ProductOrder
            {
                Order_id = prod.Order_Id,
                Product_id = prod.Product_Id,
                Quantity = prod.Quantity
            };
        }
        public static API.Models.OrderedProduct BllToApi(this BLL.Models.OrderedProduct product)
        {
            return new API.Models.OrderedProduct
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        public static API.Models.Order BllToAPI(this BLL.Models.Order order)
        {
            List<API.Models.OrderedProduct> products = new List<API.Models.OrderedProduct>();

            foreach (BLL.Models.OrderedProduct item in order.Products)
            {
                products.Add(item.BllToApi());
            }

            return new API.Models.Order
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
