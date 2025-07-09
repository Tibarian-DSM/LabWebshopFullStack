using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Webshop.API.Mapper;
using Webshop.API.Models;
using Webshop.API.Models.DTO.OrderDTO;
using Webshop.BLL.Intefaces;
using Webshop.BLL.Services;
using Webshop.DAL.Interfaces;
using Webshop.DAL.Repositories;

namespace Webshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost(nameof(CreateOrder))]
        public IActionResult CreateOrder(CreateOrderDTO order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _orderService.CreateOrder(order.ApiToBll());
                return Ok(new {message= "La commande a été crée" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost(nameof(AddProductInOrder))]
        public IActionResult AddProductInOrder(AddProductInOrderForm prod)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _orderService.AddProductinOrder(prod.ApiToBll());
                return Ok(new { message= "Le produit a été ajouté" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                Order order = new Order();
                order= _orderService.GetById(id).BllToAPI();

                if (order is null)
                {
                    return NotFound("Order not found");
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetActiveOrder/{id}")]
        public IActionResult GetActiveOrder(int id)
        {
            try
            {
                Order order = new Order();               
                
                if (_orderService.GetActiveOrder(id) is null)
                {
                    return Ok(null);
                }
                order = _orderService.GetActiveOrder(id).BllToAPI();


                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetOrdersByUserId")]
        public IActionResult GetOrdersByUserId()
        {
            try
            {
                List<Models.Order> orders = new List<Models.Order>();

                foreach (BLL.Models.Order order in _orderService.GetOrdersByUserId(int.Parse(User.FindFirst(ClaimTypes.Sid).Value)))
                {
                    orders.Add(order.BllToAPI());
                }

                if (orders is null || orders.Count == 0)
                {
                    return NotFound("No order for this user");
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("UpdateStatus/{id}")]
        public IActionResult PatchStatus(int id, PatchStatusDTO patch)
        {
            try 
            { 
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _orderService.PatchStatus(id,patch.Status);
                return Ok(new { message ="Status Update" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
