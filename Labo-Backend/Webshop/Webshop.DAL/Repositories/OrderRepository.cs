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
    public class OrderRepository : IOrderRepository
    {
        private readonly Connection _connection;

        public OrderRepository(Connection connection)
        {
            _connection = connection;
        }
        public void AddProductinOrder(ProductOrder product)
        {
            Command command = new Command("INSERT INTO [dbo].[ProductOrder]([Product_Id],[Order_Id], [Quantity])" +
                                            "VALUES (@Product_Id,@Order_Id,@Quantity)", false);

            command.AddParameter("Product_Id",product.Product_id);
            command.AddParameter("Order_Id",product.Order_id);
            command.AddParameter("Quantity", product.Quantity);
          



            _connection.ExecuteNonQuery(command);
        }

        public void CreateOrder(Order order)
        {
            Command command = new Command("INSERT INTO [dbo].[Order]([Date],[User_Id])" +
                                            "VALUES (@Date,@User_Id)", false);
            command.AddParameter("Date", order.Date);
            command.AddParameter("User_Id", order.User_Id);

            _connection.ExecuteNonQuery(command);
        }

        public Order GetById(int id)
        {
            Order order = new Order();
            IEnumerable<OrderedProduct> products; 

            Command commandOrderPart = new Command("SELECT O.Id , O.Date, O.User_Id,U.FirstName, U.LastName,U.Email,O.OrderStatus " +
                                                    " FROM [dbo].[Order] O " +
                                                    "JOIN [dbo].[User] U " +
                                                    "ON O.User_Id = U.Id " +
                                                    " WHERE O.Id=@Id");
            commandOrderPart.AddParameter("Id", id);

            order = _connection.ExecuteReader(commandOrderPart, o => o.OrderDbToDal()).SingleOrDefault();

            Command commandProductPart = new Command("SELECT P.[Name],P.[Price],Image, Quantity FROM [dbo].[Product] P" +
                                                    " JOIN [dbo].[ProductOrder] PO ON PO.Product_Id = P.Id " +
                                                    "JOIN [dbo].[Order] O ON PO.Order_Id = @OId");
            commandProductPart.AddParameter("OId", order.Id);

            order.Products= _connection.ExecuteReader(commandProductPart, p => p.OPDbToDal());

            return order;
        }
        public IEnumerable<Order> GetOrdersByUserId(int id)
        {
            List<Order> orders;
            IEnumerable<OrderedProduct> products;

            Command commandOrderPart = new Command("SELECT O.Id , O.Date, O.User_Id,U.FirstName, U.LastName,U.Email,O.OrderStatus " +
                                                    " FROM [dbo].[Order] O " +
                                                    "JOIN [dbo].[User] U " +
                                                    "ON O.User_Id = U.Id " +
                                                    " WHERE U.Id=@Id");
            commandOrderPart.AddParameter("Id", id);

            orders = _connection.ExecuteReader(commandOrderPart, o => o.OrderDbToDal()).ToList();

            foreach (Order order in orders)
            {
                Command commandProductPart = new Command(
                    "SELECT P.Name , P.Price, Image, Quantity FROM [dbo].[Product] P " +
                    " JOIN [dbo].[ProductOrder] PO ON PO.Product_Id = P.Id " +
                    " WHERE PO.Order_Id = @OId"
                );
                commandProductPart.AddParameter("OId", order.Id);

                order.Products = _connection.ExecuteReader(commandProductPart, p => p.OPDbToDal()).ToList();
            }
            return orders;
        }

        public Order? GetActiveOrder(int id)
        {
            Order? order = new Order();
            IEnumerable<OrderedProduct>? products;

            Command commandOrderPart = new Command("SELECT O.Id , O.Date, O.User_Id,U.FirstName, U.LastName,U.Email,O.OrderStatus " +
                                                    " FROM [dbo].[Order] O " +
                                                    "JOIN [dbo].[User] U " +
                                                    "ON O.User_Id = U.Id " +
                                                    " WHERE U.Id=@Id AND O.OrderStatus = 'Active'");
            commandOrderPart.AddParameter("Id", id);

            order = _connection.ExecuteReader(commandOrderPart, o => o.OrderDbToDal()).SingleOrDefault();
            if (order != null)
            { 
                Command commandProductPart = new Command(
                    "SELECT P.Name , P.Price, Image, Quantity FROM [dbo].[Product] P " +
                    " JOIN [dbo].[ProductOrder] PO ON PO.Product_Id = P.Id " +
                    " WHERE PO.Order_Id = @OId"
                );
                commandProductPart.AddParameter("OId", order.Id);

                order.Products = _connection.ExecuteReader(commandProductPart, p => p.OPDbToDal()).ToList();
            }
            return order;
            }

        public void PatchStatus(int id, string status)
        {

            Command command = new Command("UPDATE [dbo].[Order] " +
                "SET [OrderStatus] = @OrderStatus " +
                "WHERE [Order].Id = @Id");
            command.AddParameter("Id", id);
            command.AddParameter("OrderStatus", status);

            _connection.ExecuteNonQuery(command);
        }
    }
}
