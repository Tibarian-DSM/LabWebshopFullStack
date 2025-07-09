using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.DAL.Interfaces
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
        public void AddProductinOrder(ProductOrder product);
        public Order GetById(int id);
        public IEnumerable<Order> GetOrdersByUserId(int id);
        public Order GetActiveOrder(int id);
        public void PatchStatus(int id , string status);
    }
}
