using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Models;

namespace Webshop.BLL.Mappers
{
    public static class ProductMapper
    {
        public static BLL.Models.Product DalToBLL(this DAL.Models.Product product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image,
            };
        }

       public static DAL.Models.Product BllToDAl(this BLL.Models.Product product)
        {
            return new DAL.Models.Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Image= product.Image
            };
        }

        public static DAL.Models.Product UpdateToDAl(this BLL.Models.Product product)
        {
            return new DAL.Models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image
            };
        }

    }
}
