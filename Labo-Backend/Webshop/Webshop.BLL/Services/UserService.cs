using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.BLL.Intefaces;
using Webshop.BLL.Mappers;
using Webshop.BLL.Models;
using Webshop.DAL.Interfaces;
using Webshop.DAL.Models;
using Webshop.DAL.Repositories;

namespace Webshop.BLL.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public IEnumerable<BLL.Models.User> Getall()
        {
            List<BLL.Models.User> users = new List<BLL.Models.User>();

            foreach(DAL.Models.User user in _userRepository.Getall())
            {
                users.Add(user.DalToBLL());
            }

            return users;
        }

        public Models.User GetById(int id)
        {
            BLL.Models.User user = _userRepository.GetbyId(id).DalToBLL();
            return user;
        }

        public BLL.Models.User GetUserByEmail(string email)
        {
            BLL.Models.User user = _userRepository.GetUserByEmail(email).DalToBLL();
            return user;
        }

        public BLL.Models.User LoginUser(string email, string password)
        {  
            try
            {
                string  hashpsw = _userRepository.GetPassword(email);

                if (!BCrypt.Net.BCrypt.Verify(password, hashpsw))
                {
                    throw new ArgumentException("Incorrect password .");
                }
                BLL.Models.User user = _userRepository.GetUserByEmail(email).DalToBLL();
                return user;
            }
            catch(ArgumentNullException ex)
            {
                throw new ArgumentException("Email incorrect");
            }

        }

        public void RegisterUser(BLL.Models.User user)
        {   string hashMdp = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password= hashMdp;
            _userRepository.RegisterUser(UserMapper.BllToDal(user));
        }

        public void UpdateUser(BLL.Models.User user)
        {
            string hashMdp = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashMdp;
            _userRepository.UpdateUser(UserMapper.BllToDal(user));
        }
    }
}
