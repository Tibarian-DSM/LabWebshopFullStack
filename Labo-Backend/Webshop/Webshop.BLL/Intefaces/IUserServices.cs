using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Models;

namespace Webshop.BLL.Intefaces
{
 public interface IUserServices
    {

            // Register
            void RegisterUser(User user);

            // Login
            User LoginUser(string email, string password);

            IEnumerable<User> Getall();

            User GetUserByEmail(string Emai);

            void UpdateUser(User user);

            User GetById(int id);

  
    }
}
