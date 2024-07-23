using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catolog.Dtos.ProductDtos;
using MultiShop.Catolog.Entities;
using MultiShop.Catolog.Settings;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catolog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> productCollection;
        private readonly IMongoCollection<Category> categoryCollection;
        private readonly IMongoCollection<ProductImage> productImageCollection;
        private readonly IMongoCollection<ProductDetail> productDetailCollection;
        private readonly IDatabaseSettings databaseSettings;
        private readonly IMapper mapper;

        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var productId = ObjectId.GenerateNewId().ToString();
            var createProduct = new Product
            {
                ProductId = productId.ToString(),
                ProductDescription = createProductDto.ProductDescription,
                ProductImageUrl = createProductDto.ProductImageUrl,
                ProductPrice = createProductDto.ProductPrice,
                CategoryId = createProductDto.CategoryId,
                ProductName = createProductDto.ProductName,                
            };
            
            if(createProduct is not null)
                await productCollection.InsertOneAsync(createProduct);

            // Product Image Tablosunu Oluşturma
            var productImage = new ProductImage
            {
                ProductId = createProduct.ProductId,
                Image1 = "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg",
                Image2 = "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg",
                Image3 = "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg",
            };

            await productImageCollection.InsertOneAsync(productImage);

            // Product Detail Tablosunu Oluşturma
            var productDetail = new ProductDetail
            {
                ProductId = createProduct.ProductId, 
                ProductDescription = "Herhangi bir açıklama bulunmamaktadır.",
                ProductInfo = "Herhangi bir bilgilendirme bulunmamaktadır.",
            };

            await productDetailCollection.InsertOneAsync(productDetail);
        }

        public async Task DeleteProductAsync(string id)
        {
            await productCollection.DeleteOneAsync(x => x.ProductId == id);
        } 

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await productCollection.Find<Product>(x => true).ToListAsync();
            var resultProductDto = mapper.Map<List<ResultProductDto>>(values);

            return resultProductDto;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await productCollection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            var getByIdProductDto = mapper.Map<GetByIdProductDto>(values);

            return getByIdProductDto;
        }

        public async Task<List<ResultProductsByCategoryDto>> GetProductListByCategoryAsync(string categoryId)
        {
            var values = await productCollection.Find(x => x.CategoryId == categoryId).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await categoryCollection.Find(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            var map = mapper.Map<List<ResultProductsByCategoryDto>>(values);

            return map;
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await productCollection.Find(x => true).ToListAsync();
            foreach(var item in values)
            {
                item.Category = await categoryCollection.Find(x =>x.CategoryId == item.CategoryId).FirstAsync();
            }
            var map = mapper.Map<List<ResultProductsWithCategoryDto>>(values);

            return map;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = mapper.Map<Product>(updateProductDto);            
            var products = await productCollection.Find(x=>x.ProductId==updateProductDto.ProductId).SingleOrDefaultAsync();

            if(values.ProductPrice != 0)
            {
                values.PreviousProductPrice = products.ProductPrice;
                await productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
            }
        }
    }
}
