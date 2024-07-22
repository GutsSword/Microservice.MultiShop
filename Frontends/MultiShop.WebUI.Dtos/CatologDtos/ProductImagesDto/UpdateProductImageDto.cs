using MultiShop.WebUI.Dtos.CatologDtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Dtos.CatologDtos.ProductImagesDto
{
    public class UpdateProductImageDto
    {
        public string ProductImageId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string ProductId { get; set; }

       // public ProductListDto Product { get; set; }
    }
}
