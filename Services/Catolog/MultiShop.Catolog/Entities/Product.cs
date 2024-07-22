﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catolog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName  { get; set; }
        public decimal? ProductPrice{ get; set; }
        public decimal? PreviousProductPrice { get; set; }
        public string? ProductImageUrl{ get; set; }
        public string? ProductDescription{ get; set; }
        public string? CategoryId{ get; set; }
        
        [BsonIgnore]   // Bu alanı veri tabanına eklememesi için BsonIgnore kullanılır.
        public Category? Category { get; set; }
    }
}
