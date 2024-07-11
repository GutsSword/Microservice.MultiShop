using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catolog.Dtos.ProductDetailDtos;
using MultiShop.Catolog.Entities;
using MultiShop.Catolog.Settings;

namespace MultiShop.Catolog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ProductDetail> productDetailCollection;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            this.mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var map = mapper.Map<ProductDetail>(createProductDetailDto);
            await productDetailCollection.InsertOneAsync(map);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await productDetailCollection.DeleteOneAsync(x=>x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await productDetailCollection.Find<ProductDetail>(x => true).ToListAsync();
            var map = mapper.Map<List<ResultProductDetailDto>>(values);

            return map;
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            var map = mapper.Map<GetByIdProductDetailDto>(values);

            return map;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var map = mapper.Map<ProductDetail>(updateProductDetailDto);
            await productDetailCollection.FindOneAndReplaceAsync(x=>x.ProductDetailId 
            == updateProductDetailDto.ProductId , map);
        }
    }
}
