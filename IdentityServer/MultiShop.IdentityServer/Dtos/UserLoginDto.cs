using System.ComponentModel.DataAnnotations;

namespace MultiShop.IdentityServer.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
