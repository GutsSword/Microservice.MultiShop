using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Dtos.CatologDtos.ProductImagesDto;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        // İmza EA
        protected void BreadcrumbValues(string controller, string action)
        {
            ViewBag.HomeBag = "Ana Sayfa";
            ViewBag.ControllerBag = controller;
            ViewBag.ActionBag = action;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            BreadcrumbValues(" Ürünler", " Ürün Resimleri");
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductImages/GetProductImagesByProductId?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductImageDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("Index/{id}")]
        [HttpPost]
        public async Task<IActionResult> Index(UpdateProductImageDto updateProductImageDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductImages/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("CreateProductImage")]
        public async Task<IActionResult> CreateProductImage()
        {
            BreadcrumbValues(" Ürünler", " Ürün Resmi Ekle");
            return View();
        }

        [HttpPost]
        [Route("CreateProductImage")]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto productImageDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(productImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/ProductImages/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteProductImage/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/ProductImages?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
            }
            return View();
        }


    }
}
