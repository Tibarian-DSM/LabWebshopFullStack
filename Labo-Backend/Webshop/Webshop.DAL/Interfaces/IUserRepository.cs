using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.DAL.Interfaces
{
    public interface IUserRepository
    {       
        // Register
        void RegisterUser(User user);

        // Login
        User LoginUser(string email, string password);

        IEnumerable<User> Getall();

        User GetUserByEmail(string email);

        void UpdateUser(User user);

        User GetbyId(int id);
        string GetPassword(string email);

    }
}
