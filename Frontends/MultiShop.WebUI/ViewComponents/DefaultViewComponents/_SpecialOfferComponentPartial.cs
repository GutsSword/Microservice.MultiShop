using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Dtos.CatologDtos.SpecailOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _SpecialOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }        

        [Route("Index")]
        public async Task<IViewComponentResult> InvokeAsync()
        {
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
    }
}
