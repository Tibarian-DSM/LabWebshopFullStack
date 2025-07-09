using System.Runtime.CompilerServices;
using Webshop.API.Models.DTO.ProductDTO;

namespace Webshop.API.Mapper
{
    public static class ProductMapper
    {

        public static BLL.Models.Product ApiToBll(this AddProductForm form)
        {
            return new BLL.Models.Product()
            {
                Name = form.Name,
                Price = form.Price,
                Description = form.Description,
                Category = form.Category,
                Image = form.Image
            };
        }

        public static API.Models.Product BllToApi(this BLL.Models.Product product)
        {
            return new API.Models.Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image
            };
        }

        public static BLL.Models.Product ApiToBll(this API.Models.Product product)
        {
            return new BLL.Models.Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Image = product.Image
            };
        }

        public static BLL.Models.Product UpdateToBll(this API.Models.DTO.ProductDTO.UpdateProductForm product)
        {
            return new BLL.Models.Product
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
