using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catolog.Dtos.ProductDtos;
using MultiShop.Catolog.Services.ProductServices;

namespace MultiShop.Catolog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService ProductService)
        {
            this.productService = ProductService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var values = await productService.GetByIdProductAsync(id);
            return Ok(values);
        }
        [HttpPost()]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await productService.CreateProductAsync(createProductDto);
            return Ok("Ürün Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProductAsync(id);
            return Ok("Ürün Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün Başarıyla Güncellendi");
        }
    }
}
