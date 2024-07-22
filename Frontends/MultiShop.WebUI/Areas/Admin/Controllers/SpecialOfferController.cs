using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.WebUI.Dtos.CatologDtos.CategoryDtos;
using MultiShop.WebUI.Dtos.CatologDtos.ProductDtos;
using MultiShop.WebUI.Dtos.CatologDtos.SpecailOfferDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        protected void BreadcrumbValues(string controller, string action)
        {
            ViewBag.HomeBag = "Ana Sayfa";
            ViewBag.ControllerBag = controller;
            ViewBag.ActionBag = action;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            BreadcrumbValues(" Özel Teklifler", " Özel Fırsat Listesi");

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }

            return View();

        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer()
        {
            BreadcrumbValues(" Özel Teklifler", " Özel Teklif Ekle");

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);

            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/SpecialOffers", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
        
        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/SpecialOffers?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
       
        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            BreadcrumbValues(" Özel Teklifler", " Özel Teklif Güncelle");

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
                return View(values);
            }
            return View();

        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7070/api/SpecialOffers/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}
