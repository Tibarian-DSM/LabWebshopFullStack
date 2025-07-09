using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Models;
using Webshop.DAL.Models;

namespace Webshop.BLL.Mappers
{
    public static class UserMapper
    {
        public static DAL.Models.User BllToDal(this Models.User user)
        {
            return new DAL.Models.User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,

            };
        }

        public static Models.User DalToBLL(this DAL.Models.User user)
        {
            return new Models.User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role=user.Role
            };
        }
    }
}
