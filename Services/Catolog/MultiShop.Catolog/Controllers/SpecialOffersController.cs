using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catolog.Dtos.CategoryDtos;
using MultiShop.Catolog.Dtos.SpecialOfferDtos;
using MultiShop.Catolog.Services.CategoryServices;
using MultiShop.Catolog.Services.SpecialOfferService;

namespace MultiShop.Catolog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService specialOfferService;

        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            this.specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await specialOfferService.GetAllSpecialOffersAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await specialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Özel Teklif Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel Teklif Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Özel Teklif Başarıyla Güncellendi");
        }
    }
}
