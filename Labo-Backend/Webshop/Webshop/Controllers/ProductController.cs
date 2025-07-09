using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webshop.API.Mapper;
using Webshop.API.Models;
using Webshop.API.Models.DTO.ProductDTO;
using Webshop.BLL.Intefaces;

namespace Webshop.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _IproductService;

        public ProductController(IProductService productService)
        {
            _IproductService = productService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(nameof(AddProduct))]
        public IActionResult AddProduct(AddProductForm form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _IproductService.AddProduct(form.ApiToBll());
                return Ok(new { message = "Nouveau produit enregistré" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<API.Models.Product> products = new List<Product>();

            foreach (BLL.Models.Product product in _IproductService.GetAll())
            {
                products.Add(product.BllToApi());
            }

            if (products is null || products.Count() == 0)
            {
                return NoContent();
            }

            return Ok(products);
        }

        [HttpGet("productsByCategory/{category}")]
        public IActionResult GetbyCategory(string category)
        {
            List<API.Models.Product> products = new List<Product>();

            foreach (BLL.Models.Product product in _IproductService.GetByCategory(category))
            {
                products.Add(product.BllToApi());
            }

            if (products is null || products.Count() == 0)
            {
                return NoContent();
            }

            return Ok(products);
        }


        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                Product product = new Product();
                product = _IproductService.GetById(id).BllToApi();

                if (product is null)
                {
                    return NotFound("Product not found");
                }
                return Ok(product);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateProductForm product)
        {
            product.Id = id; 
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _IproductService.Update(product.UpdateToBll());
                return Ok(new { message = "Le produit a bien été modifié " });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _IproductService.Delete(id);
            }
            catch(ArgumentException ex) 
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
