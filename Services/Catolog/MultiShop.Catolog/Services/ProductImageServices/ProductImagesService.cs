using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catolog.Dtos.CategoryDtos;
using MultiShop.Catolog.Dtos.ProductDetailDtos;
using MultiShop.Catolog.Dtos.ProductImagesDtos;
using MultiShop.Catolog.Entities;
using MultiShop.Catolog.Settings;

namespace MultiShop.Catolog.Services.ProductImageServices
{
    public class ProductImagesService : IProductImagesService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ProductImage> ProductImageCollection;

        public ProductImagesService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            this.mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            ProductImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var map = mapper.Map<ProductImage>(createProductImageDto);
            await ProductImageCollection.InsertOneAsync(map);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await ProductImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await ProductImageCollection.Find<ProductImage>(x => true).ToListAsync();
            var map = mapper.Map<List<ResultProductImageDto>>(values);

            return map;
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await ProductImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
            var map = mapper.Map<GetByIdProductImageDto>(values);

            return map;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var map = mapper.Map<ProductImage>(updateProductImageDto);
            await ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId
            == updateProductImageDto.ProductId, map);
        }
    }
}
