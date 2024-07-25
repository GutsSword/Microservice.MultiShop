using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catolog.Dtos.FeatureSliderDtos;
using MultiShop.Catolog.Services.FeatureSldierService;

namespace MultiShop.Catolog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService service;

        public FeatureSlidersController(IFeatureSliderService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatureSliders()
        {
            var getAllFeatureSliders = await service.GetAllFeatureSlider();
            return Ok(getAllFeatureSliders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureByIdSlider(string id)
        {
            var featureSliderById = await service.GetByIdFeatureSliderAsync(id);
            return Ok(featureSliderById);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await service.CreateFeatureSliderAsync(createFeatureSliderDto);          
            return Ok("Feature Slider Oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await service.DeleteFeatureSliderAsync(id);
            return Ok("Feature Slider Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await service.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Feature Slider Güncellendi.");
        }
    }
}
