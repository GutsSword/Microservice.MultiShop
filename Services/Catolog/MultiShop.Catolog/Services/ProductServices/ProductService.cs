using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catolog.Dtos.CategoryDtos;
using MultiShop.Catolog.Dtos.ProductDtos;
using MultiShop.Catolog.Entities;
using MultiShop.Catolog.Settings;

namespace MultiShop.Catolog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> productCollection;
        private readonly IDatabaseSettings databaseSettings;
        private readonly IMapper mapper;

        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = mapper.Map<Product>(createProductDto);
            await productCollection.InsertOneAsync(value);
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

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = mapper.Map<Product>(updateProductDto);
            await productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
