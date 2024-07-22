using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Dtos.CatologDtos.ProductDetailsDto;
using MultiShop.WebUI.Dtos.CatologDtos.ProductDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailFeatureViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailFeatureViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {         
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/"+ id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                    return View(values);
                }

                return View();

        }
    }
}
