using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webshop.API.Models.DTO;
using Webshop.API.Services;

namespace Webshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ControllerBase
    {
        private readonly GoogleCaptchaService _captchaService;

        public CaptchaController(GoogleCaptchaService captchaService)
        {
            _captchaService = captchaService;
        }


        [HttpPost("verify", Name ="Verify captcha")]
        public async Task<IActionResult> VerifyCaptcha([FromBody] CaptchaDTO dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            bool isValid = await _captchaService.VerifyTokenAsybc(dto.Token);
            if (!isValid)
            {
                return BadRequest(new { message = "Invalid captcha token" });
                
            }

            return NoContent();
        }
    }
}
