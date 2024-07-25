using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catolog.Dtos.ProductDetailDtos;
using MultiShop.Catolog.Dtos.ProductImagesDtos;
using MultiShop.Catolog.Services.ProductDetailServices;
using MultiShop.Catolog.Services.ProductImageServices;

namespace MultiShop.Catolog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImagesService productImagesService;

        public ProductImagesController(IProductImagesService ProductImageService)
        {
            this.productImagesService = ProductImageService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await productImagesService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var values = await productImagesService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetProductImagesByProductId")]
        public async Task<IActionResult> GetProductImagesByProductId(string id)
        {
            var values = await productImagesService.GetByProductIdProductImagesAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await productImagesService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün Resmi Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await productImagesService.DeleteProductImageAsync(id);
            return Ok("Ürün Resmi Detay Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await productImagesService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün Resmi Detay Başarıyla Güncellendi");
        }
    }
}
