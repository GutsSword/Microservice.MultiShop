using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catolog.Dtos.ProductDetailDtos
{
    public class CreateProductDetailDto
    {
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }

        public string ProductId { get; set; }
    }
}
