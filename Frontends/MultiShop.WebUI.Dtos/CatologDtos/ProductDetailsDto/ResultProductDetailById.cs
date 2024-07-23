using MultiShop.WebUI.Dtos.CatologDtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Dtos.CatologDtos.ProductDetailsDto
{
    public class ResultProductDetailById
    {
        public string ProductDetailId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }

        public string ProductId { get; set; }

        public ProductListDto? Product { get; set; }

    }
}
