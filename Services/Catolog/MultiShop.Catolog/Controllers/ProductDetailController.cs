using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catolog.Dtos.ProductDetailDtos;
using MultiShop.Catolog.Dtos.ProductDtos;
using MultiShop.Catolog.Services.ProductDetailServices;

namespace MultiShop.Catolog.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService ProductDetailService;

        public ProductDetailController(IProductDetailService ProductDetailService)
        {
            this.ProductDetailService = ProductDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await ProductDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values = await ProductDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost()]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Detay Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await ProductDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün Detay Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Detay Başarıyla Güncellendi");
        }
    }
}
