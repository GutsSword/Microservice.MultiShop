using System.Security.Claims;

namespace MultiShop.WebUI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId  => httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        
    }
}
