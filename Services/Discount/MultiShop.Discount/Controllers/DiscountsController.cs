using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Discount;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService service;

        public DiscountsController(IDiscountService service)
        {
            this.service = service;
        }

        [HttpGet("GetDiscountCouponList")]
        public async Task<IActionResult> CouponList()
        {
            var values = await service.GetAllCouponsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCoupon(int id)
        {
            var values = await service.GetByIdCouponAsync(id);
            return Ok(values);
        }
        [HttpPost("CreateDiscountCoupon")]
        public async Task<IActionResult> CreateCoupon([FromBody] CreateCouponDto createCouponDto)
        {
            await service.CreateCouponAsync(createCouponDto);
            return Ok("Kupon ekleme işlemi başarıyla tamamlandı.");
        }
        [HttpDelete("DeleteDiscountCoupon")]
        public async Task<IActionResult> DeleteCoupon([FromQuery] int id)
        {
            await service.DeleteCouponAsync(id);
            return Ok("Kupon silme işlemi başarıyla tamamlandı.");
        }
        [HttpPut("UpdateDiscountCoupon")]
        public async Task<IActionResult> UpdateCoupon([FromBody] UpdateCouponDto updateCouponDto )
        {
            await service.UpdateCouponAsync(updateCouponDto);
            return Ok("Kupon güncelleme işlemi başarıyla tamamlandı.");
        }
    }
}
