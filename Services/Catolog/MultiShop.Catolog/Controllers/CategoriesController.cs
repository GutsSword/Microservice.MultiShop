using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catolog.Dtos.CategoryDtos;
using MultiShop.Catolog.Services.CategoryServices;

namespace MultiShop.Catolog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await categoryService.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpGet("{id}") ]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var values = await categoryService.GetByIdCategoryAsync(id);
            return Ok(values);
        }
        [HttpPost()]
        public async Task<IActionResult> CreateCategory(CreateCategeoryDto createCategeoryDto)
        {
            await categoryService.CreateCategoryAsync(createCategeoryDto);
            return Ok("Kategori Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori Başarıyla Güncellendi");
        }
    }
}
