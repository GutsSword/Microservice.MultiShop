using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catolog.Dtos.SpecialOfferDtos;
using MultiShop.Catolog.Entities;
using MultiShop.Catolog.Settings;

namespace MultiShop.Catolog.Services.SpecialOfferService
{
   

    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> specialOfferCollection;
        private readonly IDatabaseSettings databaseSettings;
        private readonly IMapper mapper;

        public SpecialOfferService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            specialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var map = mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await specialOfferCollection.InsertOneAsync(map);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
        {
            var result = await specialOfferCollection.Find(x => true).ToListAsync();
            var map = mapper.Map<List<ResultSpecialOfferDto>>(result);

            return map;
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var values = await specialOfferCollection.Find(x => x.SpecialOfferId == id).FirstOrDefaultAsync();
            var map = mapper.Map<GetByIdSpecialOfferDto>(values);

            return map;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var values = mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId 
            == updateSpecialOfferDto.SpecialOfferId, values);
        }
    }
}
