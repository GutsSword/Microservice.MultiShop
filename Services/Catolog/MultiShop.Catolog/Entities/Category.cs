using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catolog.Entities
{
    public class Category
    {
        // Install Mangodb.Bson - MangoDb.Driver
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
