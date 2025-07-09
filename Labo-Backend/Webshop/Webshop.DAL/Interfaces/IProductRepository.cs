using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.DAL.Interfaces
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);
        public Product GetById(int id);
        public IEnumerable<Product> GetAll();
        public IEnumerable<Product> GetByCategory(string category);

        public void Delete(int id);
        public void Update(Product product);


    }
}
