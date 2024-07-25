using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.UserName);
            bool validateUser = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            var result = (user != null && validateUser);
            if (result)
            {
                CheckAppUserModel model = new CheckAppUserModel();
                model.UserName = userLoginDto.UserName;
                model.Id = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);

                return Ok(token);
            }
            return BadRequest("Kullanıcı Adı veya Şifre Yanlış");

        }
    }
}
