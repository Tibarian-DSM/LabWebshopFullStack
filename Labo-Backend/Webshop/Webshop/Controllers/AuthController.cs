using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Linq.Expressions;
using System.Security.Claims;
using Webshop.API.Mapper;
using Webshop.API.Models;
using Webshop.API.Models.DTO.UserDTO;
using Webshop.API.Tools;
using Webshop.BLL.Intefaces;

namespace Webshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _iUserServices;
        private readonly TokenManager _tokenManager;

        public AuthController(IUserServices iUserServices, TokenManager tokenManager)
        {
            _iUserServices = iUserServices;
            _tokenManager = tokenManager;
        }

        [HttpPost(nameof(Register))]
        public IActionResult Register(UserRegisterForm form)
        {
            try
            {
                // Vérifie si le modèle de données est valide
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // Appelle le service pour enregistrer l'user
                _iUserServices.RegisterUser(UserMappers.ApiToBll(form));

                // Retorune une réponse avec succès
                return Ok(new {message= "Utilisateur enregistré avec succès !"});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost(nameof(Login))]
        public IActionResult Login(UserLoginForm form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                User user = UserMappers.BllToApi(_iUserServices.LoginUser(form.Email, form.Password));
                if (user == null)
                {
                    return NotFound("User not found");
                }
                string token = _tokenManager.GenerateJwt(user);

                return new JsonResult(new { user = user, token = token });

            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpGet("profil")]
        public IActionResult GetProfil()
        {
            User user = new User();
             user = _iUserServices.GetById(int.Parse(User.FindFirst(ClaimTypes.Sid).Value)).BllToApi();
            if (user is null)
            {
                return NoContent();
            }
            return Ok(user);

        }
        [Authorize]
        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<API.Models.User> users = new List<API.Models.User>();

            foreach (BLL.Models.User user in _iUserServices.Getall())
            {
                users.Add(user.BllToApi());
            }

            if (users.Count == 0 || users is null)
            {
                return NoContent();
            }
            return Ok(users);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserUpdateForm user)
        {
            user.Id = id;

            try
            {
                // Vérifie si le modèle de données est valide
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                // Appelle le service pour enregistrer l'user
                    _iUserServices.UpdateUser(user.UpdateToBLL());

                // Retorune une réponse avec succès
                return Ok("Le profil de l'utilisateur a été mis à jour avec succès !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
