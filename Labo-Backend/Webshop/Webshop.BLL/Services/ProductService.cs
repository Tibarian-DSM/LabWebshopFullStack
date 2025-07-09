using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Intefaces;
using Webshop.BLL.Models;
using Webshop.BLL.Mappers;
using Webshop.DAL.Interfaces;

namespace Webshop.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _IproductRepository;

        public ProductService(IProductRepository productRepository)
        {
            _IproductRepository = productRepository;
        }
        public void AddProduct(Product product)
        {
            _IproductRepository.AddProduct(product.BllToDAl());
        }

        public void Delete(int id)
        {
            _IproductRepository.Delete(id);
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            foreach (DAL.Models.Product product in _IproductRepository.GetAll())
            {
                products.Add(product.DalToBLL());
            }

            return products;
        }

        public List<Product> GetByCategory(string category)
        {
            List<Product> products = new List<Product>();

            foreach (DAL.Models.Product product in _IproductRepository.GetByCategory(category))
            {
                products.Add(product.DalToBLL());
            }

            return products;
        }

        public Product GetById(int id)
        {
            return _IproductRepository.GetById(id).DalToBLL();
        }

        public void Update(Product product)
        {
            _IproductRepository.Update(product.UpdateToDAl());
        }


    }
}
