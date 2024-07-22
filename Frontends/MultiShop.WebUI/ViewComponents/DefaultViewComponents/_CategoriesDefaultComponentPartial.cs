using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Dtos.CatologDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _CategoriesDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CategoryListDto>>(jsonData);
                return View(values);
            }

            return View();
 
        }
    }
}
