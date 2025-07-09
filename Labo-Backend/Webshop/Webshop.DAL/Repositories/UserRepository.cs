using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tools;
using Webshop.DAL.Interfaces;
using Webshop.DAL.Mappers;
using Webshop.DAL.Models;


namespace Webshop.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Connection _connection;

        public UserRepository(Connection connection)
        {
            _connection = connection;
        }

        #region GetAll
        public IEnumerable<User> Getall()
        {

                 Command command = new Command("SELECT * FROM [dbo].[user]");
            return _connection.ExecuteReader(command, u => u.DBToDal());

        }
        #endregion
        public User GetUserByEmail(string email)
        {
            Command command = new Command("SELECT * FROM [dbo].[user] WHERE Email = @Email",false);
            command.AddParameter("Email", email);

            User user = _connection.ExecuteReader(command, u => u.DBToDal()).SingleOrDefault();

            if (user == null)
            {
                throw new ArgumentException(nameof(email), "User not found with this email");
            }
            return user;
        }
        #region Login
        public User LoginUser(string email, string password)
        {

            Command command = new Command("SELECT * FROM [dbo].[user] WHERE Email = @Email AND Password=@Password", false);

            command.AddParameter("Email", email);
            command.AddParameter("Password", password);

            return _connection.ExecuteReader(command, er => er.DBToDal()).SingleOrDefault();

        }
        #endregion
        #region Register
        public void RegisterUser(User user)
        {
            Command command = new Command("INSERT INTO [dbo].[User] ([FirstName], [LastName], [Email], [Password])" +
                                              "OUTPUT inserted.Id" +
                                             " VALUES (@FirstName, @LastName, @Email, @Password)", false);


            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Lastname", user.LastName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Password", user.Password);

            _connection.ExecuteNonQuery(command);

        }

        #endregion
        #region Update
        public void UpdateUser(User user)
        {
            Command command = new Command("UPDATE [dbo].[User]" +
                                            "SET [FirstName]=@FirstName ," +
                                            "[LastName] = @LastName," +
                                            "[Email] = @Email," +
                                            "[Password] =@Password " +
                                            "WHERE [Id] = @Id");

            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Lastname", user.LastName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Password", user.Password);
            command.AddParameter("Id", user.Id);

            _connection.ExecuteNonQuery(command);
        }
        #endregion
        #region GetPassword
        public string GetPassword(string email)
        {
            Command command = new Command("SELECT * FROM [dbo].[user] WHERE Email = @email",false);
            command.AddParameter("Email", email);
            User user = _connection.ExecuteReader(command, er => er.DBToDal()).SingleOrDefault();

            if (user is null)
            {
                throw new ArgumentNullException(nameof(email), "Email inexistant");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentNullException(nameof(user.Password), "Mot de passe non défini");
            }

            return user.Password;

        }

        public User GetbyId(int id)
        {
            Command command = new Command("SELECT * FROM [dbo].[user] WHERE Id = @Id", false);
            command.AddParameter("Id", id);

            User user = _connection.ExecuteReader(command, u => u.DBToDal()).SingleOrDefault();

            if (user == null)
            {
                throw new ArgumentException(nameof(id), "User not found with this id");
            }
            return user;

        }
        #endregion
    }
}
