using Webshop.API.Models;
using Webshop.API.Models.DTO.UserDTO;
using Webshop.BLL.Models;

namespace Webshop.API.Mapper
{
    public static class UserMappers
    {
        public static BLL.Models.User ApiToBll(this  UserRegisterForm form)
        {
            return new BLL.Models.User()
            {  
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Password = form.Password
            };
        }

        public static API.Models.User BllToApi(this BLL.Models.User user)
        {
            return new API.Models.User()
            {   
                Id = user.Id, 
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,

    };
        }

        public static BLL.Models.User UpdateToBLL(this UserUpdateForm user)
        {
            return new BLL.Models.User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
