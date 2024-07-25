using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Dtos.CatologDtos.CommentDto;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("ProductList/Index/{categoryId?}")]
        public IActionResult Index(string categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }
        public IActionResult ProductDetail(string id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommendDto createCommendDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommendDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7075/api/Comments/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductDetail", new { id = createCommendDto.ProductId });
            }
            // Eğer hata olursa, tekrar yorum ekleme formunu göster
            return RedirectToAction("ProductDetail", new { id = createCommendDto.ProductId });
        }

  
    }
}
