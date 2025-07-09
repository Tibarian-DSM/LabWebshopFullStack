using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.BLL.Intefaces
{
    public interface IOrderService
    {
        public void CreateOrder(BLL.Models.Order order);
        public void AddProductinOrder(BLL.Models.ProductOrder product);
        public BLL.Models.Order GetById(int id);
        public BLL.Models.Order GetActiveOrder(int id);
        public List<BLL.Models.Order> GetOrdersByUserId(int id);

        public void PatchStatus(int id, string status);
    }
}
