using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MultiShop.Catolog.Entities;

namespace MultiShop.Catolog.Dtos.ProductDetailDtos
{
    public class GetByIdProductDetailDto
    {
        public string ProductDetailId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }

        public string ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
