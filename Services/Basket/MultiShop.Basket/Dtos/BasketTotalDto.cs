namespace MultiShop.Basket.Dtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; } // Identity Server
        public string? DicountCode { get; set; }
        public int? DiscountRate {  get; set; }
        public List<BasketItemDto> BasketItems { get; set; }

        public decimal TotalPrice 
        { 
            get=> BasketItems.Sum(x=>x.Price*x.Quantity); 
        }
    }
}
