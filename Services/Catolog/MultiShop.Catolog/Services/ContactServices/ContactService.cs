using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catolog.Dtos.ContactDtos;
using MultiShop.Catolog.Entities;
using MultiShop.Catolog.Settings;

namespace MultiShop.Catolog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<Contact> contactCollection;

        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            this.mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
        }


        public async Task DeleteContactAsync(string id)
        {
            await contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContact()
        {
            var values = await contactCollection.Find(x => true).ToListAsync();
            var map = mapper.Map<List<ResultContactDto>>(values);

            return map;
        }

        public async Task<ResultContactById> GetByIdContactAsync(string id)
        {
            var ContactById = await contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            var map = mapper.Map<ResultContactById>(ContactById);

            return map;
        }

        public async Task UpdateContactAsync(UpdateContactById updateContactDto)
        {
            var map = mapper.Map<Contact>(updateContactDto);
            await contactCollection.FindOneAndReplaceAsync(x => x.ContactId
            == updateContactDto.ContactId, map);
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var map = mapper.Map<Contact>(createContactDto);
            await contactCollection.InsertOneAsync(map);
        }
       
    }
}
