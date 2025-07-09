using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Intefaces;
using Webshop.BLL.Mappers;
using Webshop.DAL.Interfaces;
using Webshop.DAL.Models;
using Webshop.DAL.Repositories;

namespace Webshop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) 
        { 
            _orderRepository = orderRepository;
        }

        public void AddProductinOrder(Models.ProductOrder product)
        {
            _orderRepository.AddProductinOrder(product.BllToDal());
        }

        public void CreateOrder(Models.Order order)
        {
            _orderRepository.CreateOrder(order.BllToDal());
        }

        public Models.Order? GetActiveOrder(int id)
        {
            if(_orderRepository.GetActiveOrder(id) is null)
            {
                return null;
            }
            Order OrderToMap = _orderRepository.GetActiveOrder(id);
            return OrderToMap.DalToBll();
        }

        public Models.Order GetById(int id)
        {
            Order OrderToMap = _orderRepository.GetById(id);
            return OrderToMap.DalToBll();
        }

        public  List<Models.Order> GetOrdersByUserId(int id)
        {
            List<Models.Order> orders = new List<Models.Order>();

            foreach (DAL.Models.Order order in _orderRepository.GetOrdersByUserId(id))
            {
                orders.Add(order.DalToBll());
            }

            return orders;
        }

        public void PatchStatus(int id, string status)
        {
            _orderRepository.PatchStatus(id, status);
        }
    }
}
