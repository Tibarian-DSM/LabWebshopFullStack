using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Models;

namespace Webshop.BLL.Intefaces
{
    public interface IProductService
    {
        public void AddProduct(Product product);
        public Product GetById(int id);
        public List<Product> GetAll();
        public List<Product> GetByCategory(string category);
        public void Delete(int id);
        public void Update(Product product);
    }
}
