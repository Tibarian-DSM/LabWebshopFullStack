using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using Webshop.DAL.Interfaces;
using Webshop.DAL.Mappers;
using Webshop.DAL.Models;

namespace Webshop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Connection _connection;

        public ProductRepository(Connection connection)
        {
            _connection = connection;
        }
        public void AddProduct(Product product)
        {
            Command command = new Command("INSERT INTO [dbo].[Product] ([Name],[Price],[Description],[Category],[Image])" +
                                "VALUES (@Name ,@Price,@Description,@Category,@Image)",false);

            command.AddParameter("Name",product.Name);
            command.AddParameter("Price",product.Price);
            command.AddParameter("Description",product.Description);
            command.AddParameter("Category",product.Category);
            command.AddParameter("Image", product.Image);

            _connection.ExecuteNonQuery(command);
                                
        }

        public void Delete(int id)
        {
            Command command = new Command("DELETE FROM [dbo].[product] WHERE Id = @Id");
            command.AddParameter("Id", id);

            _connection.ExecuteNonQuery(command);
        }

        public IEnumerable<Product> GetAll()
        {
            Command command = new Command ("SELECT * FROM [dbo].[Product]", false);

             return _connection.ExecuteReader(command, p => p.ProductDbToDal());
        }

        public Product GetById(int id)
        {
            Product product = new Product();
            Command command = new Command("SELECT * FROM [dbo].[Product] WHERE Id = @Id", false);
            command.AddParameter("Id", id);
    
            product = _connection.ExecuteReader(command, p => p.ProductDbToDal()).SingleOrDefault();

            if (product is null)
            {
                throw new ArgumentException(nameof(id), "Product not found with this id");
            }
            return product;
        }

        public IEnumerable<Product> GetByCategory(string category)
        {
            Command command = new Command("SELECT * FROM [dbo].[Product] WHERE [Category] = @Category ", false);
            command.AddParameter("Category",category);

            return _connection.ExecuteReader(command, p => p.ProductDbToDal());
        }

        public void Update(Product product)
        {
            Command command = new Command("UPDATE [dbo].[Product] " +
                                          "SET [Name] = @Name," +
                                          "[Price]= @Price, " +
                                          "[Description]=@Description," +
                                          "[Category] = @Category, " +
                                          "[Image] = @Image " +
                                          "WHERE Id = @Id",false);

            command.AddParameter ("Id", product.Id);
            command.AddParameter ("Name", product.Name);
            command.AddParameter ("Description", product.Description);
            command.AddParameter ("Category",product.Category);
            command.AddParameter ("Price",product.Price);
            command.AddParameter("Image", product.Image);

            _connection.ExecuteNonQuery(command);
        }
    }
}
