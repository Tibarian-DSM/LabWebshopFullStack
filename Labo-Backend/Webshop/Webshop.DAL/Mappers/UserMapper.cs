using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Models;

namespace Webshop.DAL.Mappers
{
    public static class UserMapper
    {
        public static User DBToDal(this IDataRecord record)
        {
            return new User()
            {
                Id = (int)record["Id"],
                FirstName = (string)record["Firstname"],
                LastName = (string)record["Lastname"],
                Email = (string)record["Email"],
                Password = (string)record["Password"],
                Role = (string)record["Role"]

            };
        }

     
    }
}
