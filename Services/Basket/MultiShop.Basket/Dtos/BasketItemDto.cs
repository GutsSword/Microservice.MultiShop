namespace MultiShop.Basket.Dtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }  // MongoDb' den gelen prop.
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
