using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catolog.Dtos.FeatureSliderDtos;
using MultiShop.Catolog.Entities;
using MultiShop.Catolog.Services.FeatureSldierService;
using MultiShop.Catolog.Settings;

namespace MultiShop.Catolog.Services.NewFolder
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<FeatureSlider> featureSliderCollection;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            this.mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var map = mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await featureSliderCollection.InsertOneAsync(map);
                
        }
 
        public async Task DeleteFeatureSliderAsync(string id)
        {
            await featureSliderCollection.DeleteOneAsync(x=>x.FeatureSliderId == id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlider()
        {
            var featureSliders = await featureSliderCollection.Find(x => true).ToListAsync();
            var map = mapper.Map<List<ResultFeatureSliderDto>>(featureSliders);

            return map;
        }

        public async Task<GetFeatureSliderByIdDto> GetByIdFeatureSliderAsync(string id)
        {
            var featureSliderById = await featureSliderCollection.Find(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
            var map = mapper.Map<GetFeatureSliderByIdDto>(featureSliderById);

            return map;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var map = mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await featureSliderCollection.FindOneAndReplaceAsync(x=>x.FeatureSliderId 
            == updateFeatureSliderDto.FeatureSliderId,map);
        }

       
    }
}
