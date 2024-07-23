﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Dtos.CatologDtos.ProductDetailsDto;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailDescriptionFeatureViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _ProductDetailDescriptionFeatureViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id) 
        {
            // ProductId ye göre listelemeye istek at.
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductDetail/GetByProductIdProductDetail?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDetailById>(jsonData);
                return View(values);
            }

            return View();
           
        }
    }
}
