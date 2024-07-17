using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly ILoginService loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            this.basketService = basketService;
            this.loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var user = User.Claims;
            var values = await basketService.GetBasket(loginService.GetUserId);
            return Ok(values);
        }
        [HttpPost("SaveBasket")]
        public async Task<IActionResult> SaveBasket(BasketTotalDto dto)
        {
            dto.UserId = loginService.GetUserId;
            await basketService.SaveBasket(dto);
            return Ok("Sepetteki değişiklikler kaydedildi.");
        }
        [HttpPost("DeleteBasket")]
        public async Task<IActionResult> DeleteBasket()
        {
            await basketService.DeleteBasket(loginService.GetUserId);
            return Ok("Sepetteki değişiklikler kaydedildi.");
        }
    }
}
