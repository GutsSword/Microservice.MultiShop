using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Dtos.CatologDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/products/ProductsByCategory?categoryId={categoryId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductByCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
